    [Serializable]
    public class ValueHolder
    {
        public string Value01 { get; set; }                         
        public string Value02 { get; set; }		
    }
    
    public class ValueHolderCollection : List<ValueHolder>
    {}
