      class StockQuotation
        {
            internal StockQuotation(string name, decimal value)
            {
                this.Name = name;
                this.Value = value;
            }
    
    
            public string Name { get; set; }
            public decimal Value { get; set; }
        }
