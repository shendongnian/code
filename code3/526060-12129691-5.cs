             private void copywarehouse(string filename)
            {
                const string sourcePath = @"C:\Test";
                const string targetPath = @"C:\Test";
                try
                {
                    string sourceFile = Path.Combine(sourcePath, filename);
                    string destFile = Path.Combine(targetPath, "tempfile.txt");
    
    
                    string currentcontent;
                    using (var sr = new StreamReader(sourceFile))
                    {
                        currentcontent = sr.ReadToEnd();
                    }
    
                    using (var wr = new StreamWriter(destFile, false, Encoding.ASCII))
                    {
                        wr.WriteLine(currentcontent);
                    }
                }
                catch (Exception)
                {
    
                }
            }
