    public void CompareImages()
    {
        var dir1 = new DirectoryInfo(@"C:\path1");
        FileInfo[] files1 = dir1.GetFiles("*.png");
    
        var dir2 = new DirectoryInfo(@"C:\path2");
        FileInfo[] files2 = dir2.GetFiles("*.png");
        Dictionary<string, FileInfo> files2Dict = files2.ToDictionary(f => f.Name);
    
        foreach (FileInfo f1 in files1) {
            FileInfo f2;
            bool equal = true;
            if (files2Dict.TryGetValue(f1.Name, out f2) && f1.Length == f2.Length) {
                byte[] image1 = GetFileBytes(f1);
                byte[] image2 = GetFileBytes(f2);
                for (int i = 0; i < image1.Length; i++) {
                    if (image1[i] != image2[i]) {
                        equal = false;
                        break;
                    }
                }
            } else {
                equal = false;
            }
            Console.WriteLine(f1.Name + ": " + (equal ? "Images are equal" : "Images are NOT equal"));
        }
    }
    
    private static byte[] GetFileBytes(FileInfo f)
    {
        using (FileStream stream = f.OpenRead()) {
            byte[] buffer = new byte[f.Length];
            stream.Read(buffer, 0, (int)f.Length);
            return buffer;
        }
    }
