    public class DisplayNameAttribute : System.ComponentModel.DisplayNameAttributes
    {
            private string name;
        
            public DisplayNameAttribute() { }
            public DisplayNameAttribute(String name) { this.name = name; }
        
            public override string DisplayName 
            { 
                get 
                { 
                    return DisplayNameValue;
                } 
            }
        
            public string DisplayNameValue
            {
                get
                {
                    /* e.g logic for reading from dictionary file */
                    return myDictionary[name];
                }
                set
                {
                    name = value;
                }
            }
        }
    }
