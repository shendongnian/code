    public interface IAdressAndId
        {
            int ID { get; set; }
            string Address { get; set; }
        }
        public interface INameAndDate
        {
            string Name { get; set; }
            DateTime? DateTime { get; set; }
        }
        public class TestClass : IAdressAndId, INameAndDate
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public DateTime? DateTime { get; set; }
        public string Address { get; set; }
    }
