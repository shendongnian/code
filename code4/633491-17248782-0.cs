    class Document
    {
        public int Id {get;set;}
        public String Name {get;set;}
        public DocumentTemplate DocumentTemplate{get;set;}
    }
    
    class DocumentTemplate
    {
        public int Id {get;set;}
        public String Description {get;set;}
        public String Name {get;set;}
    
        public IList<Page> Pages {get;set;}
    }
    
    class Page
    {
        public int Id {get;set;}
        public string Text {get;set;}
    }
    
