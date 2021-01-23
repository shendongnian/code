    public class Father : Person
        {
            private string name;
            public Father(string Name)
            {
                name = Name;
    
            }
            public Father()
            { }
    
            public override string ToString()
            {
                return this.name;
            }
        }
