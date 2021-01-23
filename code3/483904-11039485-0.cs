    class ObjectContainer
    {
        private object item;
        
        public object Item 
        {
            get { return item; }
            set { item = value; }
        }
    }
    class StringContainer : ObjectContainer
    {
        public new virtual string Item
        {
            get { return base.Item as string; }
            set { base.Item = value as string; }
        }
    }
    class QuotedStringContainer : StringContainer
    {
        public override string Item
        {
            get { return "\"" + base.Item + "\""; }
        }
    }
