    protected class roleProperties
    {
        public string roleName { get; set; }
        public IList<string> functionTitle { get; private set;}
        public roleProperties(){
            functionTitle = new List<string>();
        }
    }
