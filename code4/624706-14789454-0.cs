    public string Download()
    {
       Download(Encoding.UTF8);
    }
    
    public string Download(Encoding contentEncoding)
    {
       defaultEncoding = contentEncoding ?? Encoding.UTF8;
       // codes...
    }
