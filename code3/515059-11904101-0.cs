    public class MyObjType1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class MyObjType2
    {
        public string Reference { get; set; }
        public override string ToString()
        {
            return Reference;
        }
    }
