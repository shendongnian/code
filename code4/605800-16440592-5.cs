    // Before
    class FileRepository
    {
       public FileRepository() { }
    
       public void Save( string content, string xml )
       {
          var writer = new MyXmlFileWriter();
          writer.Write(content,xml);
       }
    }
    
    // After
    class FileRepository
    {
       private IFileWriter writer = null;
    
       public FileRepository() : this( new MyXmlFileWriter() ){ }
       public FileRepository(IFileWriter writer) 
       {
          this.writer = writer;
       }
    
       public void Save( string path, string xml)
       {
          this.writer.WriteData(path, xml);
       }
    }
