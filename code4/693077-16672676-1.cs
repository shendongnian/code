    class BlueBank : Bank
        {
            //All is ok, no validate 
            public override string AccountNumber { get; set; }
    
            public override double Amount { get; set; }
    
            public override int InvoicePeriod { get; set; }
    
        }
    class RedBank : Bank
        {
            [Required()]
            public override string AccountNumber { get; set; }
    
            public override double Amount { get; set; }
            [Range(0,0)]
            public override int InvoicePeriod { get; set; }
    
    
            public override void Validate()
            {
                List<string> errors=new List<string>();
                if (AccountNumber != "Test")
                    errors.Add("Worng Account");
                base.Validate(errors);
            }
    
        }
