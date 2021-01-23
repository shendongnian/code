    public void ExtractDiskImage(string pathToDiskImage, string extractPath, bool WaitForFinish)
    {
        ProcessStartInfo UnzipDiskImage = new ProcessStartInfo("7z.exe");
        StringBuilder str = new StringBuilder();
        str.Append("e ");
        str.Append(pathToDiskImage);
        str.Append(" -o");
        str.Append(extractPath);
        str.Append(" * -r");
        UnzipDiskImage.Arguments = str.ToString();
        UnzipDiskImage.WindowStyle = ProcessWindowStyle.Hidden;
        Process process = Process.Start(UnzipDiskImage);
        if(WaitForFinish == true)
        {
            process.WaitForExit(); //My app had to wait for the extract to finish
        }
    }
