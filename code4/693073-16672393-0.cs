    class FileParser
    {
    public event EventHandler ParsingFailedEvent;
    
    public void ParseFile()
    {
    // 1. Parse the file
    // 2. File structure isn't correct, raise event!
    
                ParsingFailedEvent.Invoke(sender, e);
    }
    
    }
    
    class DataHandler
    {
    private FileParser fp = new FileParser();
    public DataHandler()
    {
    
                fp.ParsingFailedEvent+= new EventHandler(this.FileParsingHandler);
    }
    
    public void FileParsingHandler(object sender, EventArgs e)
            {
    // do something, maybe display a MessageBox
    }
    
    }
