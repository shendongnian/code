        public class Customer
        {
            [Remote("CardExisting", "Validation", AdditionalFields = "CardNumber,LastName")]
            public string FirstName { get; set; }
            [Remote("CardExisting", "Validation", AdditionalFields = "FirstName,CardNumber")]
            public string LastName { get; set; }
            [Remote("CardExisting", "Validation", AdditionalFields = "FirstName,LastName")]
            public string CardNumber { get; set; }
        }
