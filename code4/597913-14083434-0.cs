        public class Address
        {
            public int ID { get; set; 
            public string AddressLine { get; set; }
            public string City { get; set; }
            public int StateID { get; set; }
            public virtual State State { get; set; }
        }
