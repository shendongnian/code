    public enum SaveFormat
    {
        SaveFormat1 = 0,
        SaveFormat2 = 1
    };
    
    namespace MyProject1
    ...
        public void Save()
        {
            MyProject2.SaveDocument( SaveFormat.SaveFormat1 );        
        }
    
    namespace MyProject2
    ...
        ...
        public void SaveDocument( SaveFormat format )
        {
            WdFormat localFormat = this.Translate( format );        
            ...
        }
    
        private WdFormat Translate( SaveFormat format )
        {
            switch( format )
            {
                case SaveFormat1:
                    return WDFormat1;
                case SaveFormat2:
                    return WDFormat2;
                default:
                    return WDFormat3;
             }
        }
