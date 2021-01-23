        public class TestClass
        {
            public decimal Cat { get; set; }
            public decimal Dog { get; set; }
            [Newtonsoft.Json.JsonProperty]
            private Price Price { get; set; }
            [Newtonsoft.Json.JsonIgnore]
            public decimal InitialPrice
            {
                get { return this.Price.Initial; }
            }
            [Newtonsoft.Json.JsonIgnore]
            public decimal NewPrice
            {
                get { return this.Price.New; }
            }
        }
        class Price
        {
            public decimal Initial { get; set; }
            public decimal New { get; set; }
        }
