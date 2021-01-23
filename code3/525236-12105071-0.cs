    public static bool ZipIt(string sourcePath, string destinationPath)
            {          
                List<string> ListOfFiles = GetListOfFiles(sourcePath);
                try
                {
                    string OutPath = destinationPath + ".zip";               
                    int TrimLength = (Directory.GetParent(sourcePath)).ToString().Length;
                    TrimLength += 1;
                    //remove '\'
                   FileStream ostream;
                    byte[] obuffer;               
                    ZipOutputStream oZipStream = new  ZipOutputStream(System.IO.File.Create(OutPath));                    
                    oZipStream.Password = EncodePassword("Password");
                    oZipStream.SetLevel(9);
                    // 9 = maximum compression level
                    ZipEntry oZipEntry;
                    foreach (string Fil in ListOfFiles.ToArray()) // for each file, generate a zipentry
                    {
                        oZipEntry = new ZipEntry(Fil.Remove(0, TrimLength));    
                        oZipStream.PutNextEntry(oZipEntry);    
    
                        if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                        {
                            ostream = File.OpenRead(Fil);    
                            obuffer = new byte[ostream.Length];
                            ostream.Read(obuffer, 0, obuffer.Length);    
                            oZipStream.Write(obuffer, 0, obuffer.Length);    
                            ostream.Close();    
                        }
                    }
                    oZipStream.Finish();
                    oZipStream.Close();               
                    return true;
                }
                catch (Exception ex)           
                {    
                    return false;
                }
            }            
            
             public static string EncodePassword(string originalPassword)
             {                         
                Byte[] encodedBytes;  
                encodedBytes = ASCIIEncoding.Default.GetBytes(originalPassword);              
                return BitConverter.ToString(encodedBytes);
             }
