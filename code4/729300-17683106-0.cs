    public Test(int a = 1, int b = 2, int c = 3)
        : this(new StreamWriter(File.Create(@"app.log")), a, b, c)
    {
    }
    
    public Test(StreamWriter sw, int a = 1, int b = 2, int c = 3)
