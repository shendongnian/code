        public static void SaveLog(string exc)
        {
                FileStream objFS = null;
                
                    string strFilePath = "Exception.log";
                    if (!File.Exists(strFilePath))
                    {
                        objFS = new FileStream(strFilePath, FileMode.Create);
                    }
                    else
                        objFS = new FileStream(strFilePath, FileMode.Append);
                    using (StreamWriter Sr = new StreamWriter(objFS))
                    {
                        Sr.WriteLine(System.DateTime.Now.ToShortTimeString() + "---" + exc);
                    }
                
            
        }
