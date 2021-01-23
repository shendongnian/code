    namespace TestStub
    {
        using System;
        using System.IO;
        using System.Text;
 
        public class Program
        {
            private static char[] CSV = { ',', ',' };
            private static bool csvFound = false;
            /// <summary>
            /// This is the console program entry point
            /// </summary>
            /// <param name="args">A list of any command-line args passed to this application when started</param>
            public static void Main(string[] args)
            {
                // Change this to use args[0] if you like 
                string myInitialPath = @"C:\Temp";
                string[] myListOfFiles;
                try
                {
                    myListOfFiles = EnumerateFiles(myInitialPath);
                    foreach (string file in myListOfFiles)
                    {
                        Console.WriteLine("\nFile {0} is comprised of {1}% CSV delimited lines.",
                            file, 
                            ScanForCSV(file));
                    }
                    Console.WriteLine("\n\nPress any key to exit.");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "Error processing {0} for CSV content: {1} :: {2}", 
                        myInitialPath, 
                        ex.Message, 
                        ex.InnerException.Message);
                }
            }
            /// <summary>
            /// Get a list of all files for the specified path
            /// </summary>
            /// <param name="path">Directory path</param>
            /// <returns>String array of files (with full path)</returns>
            public static string[] EnumerateFiles(string path)
            {
                string[] arrItems = new string[1];
   
                try
                {
                    arrItems = Directory.GetFiles(path);
                    return arrItems;
                }
                catch (Exception ex)
                {
                    throw new System.IO.IOException("EnumerateFilesAndFolders() encountered an error:", ex);
                }
            }
            /// <summary>
            /// Determines if the supplied file has comma separated values
            /// </summary>
            /// <param name="filename">Path and filename</param>
            /// <returns>Percentage of lines containing CSV elements -vs- those without</returns>
            public static float ScanForCSV(string filename)
            {
                //
                // NOTE: You should look into one of the many CSV libraries
                // available. This method will not carefully scruitinize
                // the file to see if there's a combination of delimeters or
                // even if it's a plain-text (e.g. a newspaper article)
                // It just looks for the presence of commas on multiple lines
                // and calculates a percentage of them with and without
                //
                float totalLines = 0;
                float linesCSV = 0;
   
                try
                {
                    using (StreamReader sReader = new StreamReader(filename))
                    {
                        int elements = 0;
                        string line = string.Empty;
                        string[] parsed = new string[1];
                        while (!sReader.EndOfStream)
                        {
                            ++totalLines;
                            line = sReader.ReadLine();
                            parsed = line.Split(CSV);
                            elements = parsed.Length;
                            if (elements > 1)
                            {
                                ++linesCSV;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new System.IO.IOException(string.Format("Problem accessing [{0}]: {1}", filename, ex.Message), ex);
                }
                return (float)((linesCSV / totalLines) * 100);
            }
        }  
    }
}
