    public interface IAdressAndId
        {
            public int ID { get; set; }
            public string Address { get; set; }
        }
        public interface INameAndDate
        {
            public string Name { get; set; }
            public DateTime? DateTime { get; set; }
        }
        public class TestClass : IAdressAndId, INameAndDate
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public DateTime? DateTime { get; set; }
        public string Address { get; set; }
    }
