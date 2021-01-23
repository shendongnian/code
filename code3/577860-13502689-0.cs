    public Form1()
    {
        // Reading pictures from My Pictures:
        string path = Environment.GetFolderPath(Environment.SpecialFolders.MyPictures);
        DictionaryInfo myPictures = new DictionaryInfo(path);
        FPictureFiles = myPictures.GetFiles("*.jpg", SearchOption.AllDirectories).ToList();
    }
    private List<FileInfo> FPictureFiles;
    private Random FRandom = new Random();
    private void button1_Click(object sender)
    {
        pictureBox1.Load(PickFile());
        pictureBox2.Load(PickFile());
    }
    private string PickFile()
    {
        if (FPictureFiles.Count == 0) throw new Exception("No more picture files");
        int index = FRandom.Next(FPictureFiles.Count);
        string filename = FPictureFiles[index].FullName;
        FPictureFiles.RemoveAt(index);
        return filename;
    }
