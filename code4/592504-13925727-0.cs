    public static void StoreSavedResultImage(string filename, WriteableBitmap wb)
            {
                using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isf.FileExists(filename))
                        isf.DeleteFile(filename);
    
                    using (IsolatedStorageFileStream fs = isf.CreateFile(filename))
                    {
                        wb.SaveJpeg(fs, wb.PixelWidth, wb.PixelHeight, 0, 100);
                        fs.Close();
                        wb = null;
                        img = null;
                    }
                }
            }
