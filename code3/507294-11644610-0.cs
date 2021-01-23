    class Records
    {
        public List<Record> records { get; set }
    }
    
    class Record
    {
        public RecordDatabase database { get; set }
        ...
        public int rec_number { get; set }
        ...
    }
    
    class RecordDatabase
    {
        public string path { get; set }
        public string name { get; set }
    }
    
    ...
