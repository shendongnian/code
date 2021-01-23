    class SomeTypeEditableContent : IEditableContent
    {
        public DatabaseContext.Content Content { get; set; }
        public SomeTypeEditableContent(DatabaseContext.Content c)
        {
            Content = c;
        }
    }
