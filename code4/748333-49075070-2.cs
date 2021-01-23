    public class CustomerList
    {
        [JsonConverter(typeof(MyListConverter))]
        public List<Customer> customer { get; set; }
    }
