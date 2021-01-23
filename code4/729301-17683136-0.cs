    public Test(int a = 1, int b = 2, int c = 3, StreamWriter sw = null)    
    {
        if (sw == null)
            sw = new StreamWriter(File.Create(@"app.log"));
        this.a = a;
        this.b = b;
        this.c = c;
    }
