        public MyEntryElement(ConfigElement parent)
            : base(parent)
        {
            if ( String.IsNullOrEmpty(ID) )
            {
                ID = Guid.NewGuid().ToString();
            }
        }
