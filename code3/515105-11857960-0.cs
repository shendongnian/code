        public static void CopyToZip(string inArchive, string outArchive, string tempPath)
        {
            ZipFile inZip = null;
            ZipFile outZip = null;
            try
            {
                inZip = new ZipFile(inArchive);
                outZip = new ZipFile(outArchive);
                List<string> tempNames = new List<string>();
                List<string> originalNames = new List<string>();
                int I = 0;
                foreach (ZipEntry entry in inZip)
                {
                    if (!entry.IsDirectory)
                    {
                        string tempName = Path.Combine(tempPath, "tmp.tmp");
                        string oldName = entry.FileName;
                        byte[] buffer = new byte[4026];
                        Stream inStream = null;
                        FileStream stream = null;
                        try
                        {
                            inStream = entry.OpenReader();
                            stream = new FileStream(tempName, FileMode.Create, FileAccess.ReadWrite);
                            int size = 0;
                            while ((size = inStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                stream.Write(buffer, 0, size);
                            }
                            inStream.Close();
                            stream.Flush();
                            stream.Close();
                            inStream = new FileStream(tempName, FileMode.Open, FileAccess.Read);
                            outZip.AddEntry(oldName, inStream);
                            outZip.Save();
                        }
                        catch (Exception exe)
                        {
                            throw exe;
                        }
                        finally
                        {
                            try { inStream.Close(); }
                            catch (Exception ignore) { }
                            try { stream.Close(); }
                            catch (Exception ignore) { }
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
