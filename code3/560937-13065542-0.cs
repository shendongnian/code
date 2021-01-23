    StreamWriter sw;
                    string path = your file path;
    
                    if (!File.Exists(path))
                    {
    
                        sw = File.CreateText(path);
                    }
    
                    else
                    {
                        sw = File.AppendText(path);
    
                    }
                sw.WriteLine("string here");
                sw.Flush();
                sw.Close();
