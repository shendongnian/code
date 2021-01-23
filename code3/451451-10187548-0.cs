    using (var myStore = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (myStore.FileExists(tempJPEG))
        {
            myStore.DeleteFile(tempJPEG);
        }
        IsolatedStorageFileStream file = myStore.CreateFile(tempJPEG);
        int[] buf = new int[(int)c.PreviewResolution.Width * (int)c.PreviewResolution.Height];
        c.GetPreviewBufferArgb32(buf);
        WriteableBitmap wb = new WriteableBitmap((int)c.PreviewResolution.Width, (int)c.PreviewResolution.Height);
        Array.Copy(buf, wb.Pixels, buf.Length);
        wb.SaveJpeg(file, (int)c.PreviewResolution.Width, (int)c.PreviewResolution.Height, 0, 100);
    }
