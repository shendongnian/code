    public class Car
    {
        public int Id { get; set; }
        public string Descrip { get; set; }
        public MetaData CarColours { get; set; }
    }
    public MetaData : Dictionary<int, string>
    {
        public MetaData(int group){}
    }
