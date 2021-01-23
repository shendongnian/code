    public bool VerifyPhoto(string matriculation)
    {
        string dir = Txt_PhotosPath.Text;
        if(Directory.Exists(dir))
        {
            string fileName = string.Format("{0}.jpg", matriculation);
            if(File.Exists(Path.Combine(dir, fileName)))
                return true;
            else
                return false;
        }
        else
            return false;
    }
