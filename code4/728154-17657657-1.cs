    public class MyModel
    {
    
        public string SerialisedData {
            get { 
                return string.Format("[{ name = {0}, someProp = {1} ...... }]", this.Name, this.someProp .....);
            }
        }
    }
