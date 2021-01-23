        public class Item
        {
            public Item()
            {
                // Enabled by default
                Enabled = true;
            }
            public bool Enabled { get; set; }
            public string Value { get; set; }
            public override string ToString()
            {
                return Value;
            } 
        }
