    public static void SaveStreamToStorage(Stream imgStream, string fileName)
            {
                using (IsolatedStorageFile iso_storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    //Structure the path you want for your file.
                    string filePath = GetImageStorePathByFileName(fileName);
    
                    //Constants.S_STORE_PATH is the path I want to store my picture.
                    if (!iso_storage.DirectoryExists(Constants.S_STORE_PATH))
                    {
                        iso_storage.CreateDirectory(Constants.S_STORE_PATH);
                    }
                    //I skip the process when I find the same file.
                    if (iso_storage.FileExists(filePath))
                    {
                        return;
                    }
    
                    try
                    {
                        if (imgStream.Length > 0)
                        {
                            using (IsolatedStorageFileStream isostream = iso_storage.CreateFile(filePath))
                            {
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.SetSource(imgStream);
    
                                WriteableBitmap wb = new WriteableBitmap(bitmap);
                                
                                // Encode WriteableBitmap object to a JPEG stream. 
                                Extensions.SaveJpeg(wb, isostream, wb.PixelWidth, wb.PixelHeight, 0, 100);
                                
                                isostream.Close();
    
                                bitmap.UriSource = null;
                                bitmap = null;
                                wb = null;
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        if (iso_storage.FileExists(filePath))
                            iso_storage.DeleteFile(filePath);
    
                        throw e;
                    }
                }
            }
