        public class Thing
        {
            public string Life { get; set; }
            public Thing()
            {
                Life = Guid.NewGuid().ToString();
            }
        }
        public class SimpleEmail
        {
            public Thing MyThing { get; set; }
            public string From { get; set; }    
            public string Header { get; set; }    
            public string Message { get; set; }
            public SimpleEmail()
            {
                MyThing = new Thing();
            }
        }
