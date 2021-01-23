    public class MyClass
    {
        // Note that dictionary is now private.
        private Dictionary<Beep, String> Stuff { get; set; }
    
        public String this[Beep beep]
        {
            get
            {
                // This indexer is very simple, and just returns or sets 
                // the corresponding element from the internal dictionary. 
                return this.Stuff[beep];
            }
            set
            {
                this.Stuff[beep] = value;
            }
        }
        // Note that you might want Add and Remove methods as well - depends on 
        // how you want to use the class. Will client-code add and remove elements,
        // or will they be, e.g., pulled from a database?
    }
