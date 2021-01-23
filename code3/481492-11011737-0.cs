        private Dictionary<string, string> _dictionary;
 
        public Query()
        {
            _dictionary = new Dictionary<string, string>();
        } 
        public Query<T> Eq(Expression<Func<T, string>> property)
        {
            AddOperator("Eq", property.Name);
            return this;
        }
        public Query<T> StartsWith(Expression<Func<T, string>> property)
        {
            AddOperator("Sw", property.Name);
            return this;
        }
        public Query<T> Like(Expression<Func<T, string>> property)
        {
            AddOperator("Like", property.Name);
            return this;
        }
        private void AddOperator(string opName, string prop)
        {
            _dictionary.Add(opName,prop);
        }
        public void Run(T t )
        {
            //Extract props of T by reflection and Build query   
        }
    }
