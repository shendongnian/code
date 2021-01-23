    public class MyModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Tag { get; set; }        
        public string Foo { get; set; }
    }
