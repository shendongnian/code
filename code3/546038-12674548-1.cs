    class SomeTypeEditableContent : IEditableContent
    {
        public DatabaseContext.Content data { get; set; }
        public SomeTypeEditableContent(DatabaseContext.Content c)
        {
            data = c;
        }
    }
