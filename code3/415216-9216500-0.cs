    class Data
    {
        public int ID { get; set; }
        public string SomeData { get; set; }
        public string SomeOtherData { get; set; }
        //Assume there are lots of other fields here
        public override bool Equals(object obj)
        {
            Data other = obj as Data;
            if (other != null)
            {
                return ID == other.ID;
            }
            return false;
        }
    }
