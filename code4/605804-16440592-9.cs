    interface IFileWriter
    {
       bool WriteData(string location, string content);
    }
    
    class MyXmlFileWriter : IFileWriter 
    { 
       /* As before */ 
    }
