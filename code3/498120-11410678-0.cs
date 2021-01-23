    class Config
    {
        private string param; 
    
        public int ParamAsInt
        {
            get 
            { 
                return int.Parse(param); 
            }
        }
    
        public bool ParamAsBool
        {
            get 
            { 
                return bool.Parse(param); 
            }
        }
    
        public string ParamAsString
        {
            get 
            { 
                return param; 
            }
        }
    }
