    class Props
    {
        public PropType PropertyType { get; private set; }
        public Props(PropType propType)
        {
            PropertyType = propType;
        }
    }
    
    enum PropType
    {
        Int32 = 1,
        Int64 = 2,
        Bool = 3 //etc. etc.
    }
