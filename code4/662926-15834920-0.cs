    private static void convert(object source, FileSystemEventArgs f)
        {
            string FileName;
            FileName = f.FullPath;
            string FilePath;
            FilePath = f.Name;
            var watcher = source as FileSystemWatcher;
            string destinationFile = @"D:/GS/" + FilePath;
           **System.Threading.Thread.Sleep(1000);
            if (Monitor.TryEnter(lockObject))**
            {
                try
                {
                    watcher.EnableRaisingEvents = false;
                    XmlDocument xdoc = new XmlDocument();
                    try
                    {
                        xdoc.Load(FileName);
                        xdoc = null;
                    }
                    catch (XmlException xe)
                    {
                        xdoc = null;
                        using (StreamWriter w = File.AppendText(FileName))
                        {
                            Console.WriteLine(xe);
                            w.WriteLine("</title>");
                            w.WriteLine("</titleContent>");
                            Console.WriteLine("1st");
                        }
                    }
                  System.Threading.Thread.Sleep(2000);
                    XPathDocument myXPathDoc = new XPathDocument(new StreamReader(FileName, System.Text.Encoding.GetEncoding("windows-1256")));
                    XslCompiledTransform myXslTrans = new XslCompiledTransform();
                    myXslTrans.Load("D:/GS/xsl/test.xsl");
                    XmlTextWriter myWriter = new XmlTextWriter(destinationFile, null);
                    myWriter.Formatting = Formatting.Indented;
                    myWriter.Indentation = 4;
                    myXslTrans.Transform(myXPathDoc, null, myWriter);
                    myWriter.Close();
                    Console.WriteLine("2nd");
                 
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
                finally
                {
                    Monitor.Exit(lockObject);
                    watcher.EnableRaisingEvents = true;
                    Console.WriteLine("Finally");
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }
        }
            }
