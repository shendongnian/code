            interface IGenerateBill
            {
                void GenerateBill();
                string SupportedCountry { get; }
            }
    
            class UserInUs : IGenerateBill
            {
            //Implement IGenerateBill members
    
                public void GenerateBill()
                {
                    //generate bill
                }
    
                public string SupportedCountry
                {
                    get { return "US"; }
                }
            }
            class UserInRussia : IGenerateBill
            {
            //Implement IGenerateBill members
    
                public void GenerateBill()
                {
                    //generate bill
                }
    
                public string SupportedCountry
                {
                    get { return "Russia"; }
                }
            }
    
