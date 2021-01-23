    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime LastChecked = DateTime.Now;
    
                IDictionary<string, FileDetails> fileDetails = new Dictionary<string, FileDetails>(StringComparer.OrdinalIgnoreCase);
                IList<string> tempFileList = new List<string>();
    
                try
                {
                    string[] files = System.IO.Directory.GetFiles(@"C:\Test", "*.jrn", System.IO.SearchOption.AllDirectories);
    
                    foreach (string file in files)
                    {
                        string currentfilename = file;
                        string currentcontent = string.Empty;
    
                        if (!fileDetails.Keys.Contains(file))
                        {
                            fileDetails[file] = new FileDetails(copywarehouse(file));
                            //do_some_processing();
                        }
    
                        try
                        {
                            using (StreamReader sr = new StreamReader(file))
                            {
                                currentcontent = sr.ReadToEnd();
                            }
                        }
                        catch (Exception)
                        {
                            // Let the user know what went wrong.
                        }
    
                        fileDetails[file].AddContent(currentcontent);
                    }
    
                    //TODO: Check using the file modified time. Avoids unnecessary reading of file.
                    foreach (var fileDetail in fileDetails.Values)
                    {
                        //checking
                        try
                        {
                            string tempFileContent = string.Empty;
                            string currentcontent = fileDetail.GetContent();
    
                            using (StreamReader sr = new StreamReader(fileDetail.TempFileName))
                            {
                                tempFileContent = sr.ReadToEnd();
                                sr.Close();
                            }
    
                            if (!(0 == string.Compare(tempFileContent, currentcontent)))
                            {
                                if (currentcontent.Contains(tempFileContent))
                                {
                                    string newContent = tempFileContent.Substring(currentcontent.Length);
    
                                    using (StreamWriter filenew = new StreamWriter(fileDetail.TempFileName, true, Encoding.ASCII))
                                    {
                                        filenew.WriteLine(newContent);
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            // Let the user know what went wrong.
                        }
    
                    }
                }
                catch (Exception)
                {
                }
            }
    
            private static string copywarehouse(string filename)
            {
                string sourcePath = @"C:\Test";
                string targetPath = @"C:\Test";
    
                string sourceFile = System.IO.Path.Combine(sourcePath, filename);
                string destFile = System.IO.Path.Combine(targetPath, filename+ "tempfile.txt");
    
                try
                {
                    System.IO.File.Copy(sourceFile, destFile, true);
                }
                catch (Exception)
                {
                }
    
                return destFile;
            }
    
            internal class FileDetails
            {
                public string TempFileName { get; private set; }
                private StringBuilder _content;
    
                public FileDetails(string tempFileName)
                {
                    TempFileName = tempFileName;
                    _content = new StringBuilder();
                }
    
                public void AddContent(string content)
                {
                    _content.Append(content);
                }
    
                public string GetContent()
                {
                    return _content.ToString();
                }
            }
        }
    }
