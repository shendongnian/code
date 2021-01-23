    public class MyModel
    {
        public int Id { get; set; }
        public string TimeStamp { get; set; }
    }
    new MyModel { Id = 123, TimeStamp = DateTime.Now.ToString("o") };
