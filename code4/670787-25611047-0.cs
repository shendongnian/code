    Bitmap ReadBitmapFromFile(String s_Path)
    {
        using (FileStream i_Stream = new FileStream(s_Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (Bitmap i_Bmp = new Bitmap(i_Stream))
            {
                return new Bitmap(i_Bmp);
            }
        }
    }
