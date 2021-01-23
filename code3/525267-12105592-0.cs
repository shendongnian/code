    private FileStream fs;
    private StreamWriter sw;
    
    public MyClass()
    {
        fs = new FileStream(@"D:\Hello.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite); 
        sw = new StreamWriter(fs);
    }
