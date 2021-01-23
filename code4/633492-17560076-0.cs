    class Page
    {
        public int Id {get;set;}
        public string Text {get;set;}
        public int? DocumentId { get; set; } // non-mandatory relationship to Document
        public int? DocumentTemplateId { get; set; } // non-mandatory relationship to DocumentTemplate
        // ... navigation properties
    }
