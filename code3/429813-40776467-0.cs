    class A
    {   
        [NotMapped()]
        public Dictionary<int, DataType> Data {get; set}
        
        //refers to Data.Values
        public ICollection<DataType> DataAsList {get; set}        
        
    }
