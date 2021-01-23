    public string ReadLastLine(string path)
            {
                string returnValue = "";
                FileStream fs = new FileStream(path, FileMode.Open);
                for (long pos = fs.Length - 2; pos > 0; --pos)
                {
                    fs.Seek(pos, SeekOrigin.Begin);               
                    StreamReader ts = new StreamReader(fs);
                    returnValue = ts.ReadToEnd();
                    int eol = returnValue .IndexOf("\n");
                    if (eol >= 0)
                    {                    
                        fs.Close();
                        return returnValue .Substring(eol + 1);
                    }                
                }
                fs.Close();
                return returnValue ;
            }
