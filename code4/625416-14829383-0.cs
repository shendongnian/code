    class Model {
        private dynamic obj;
        public int Id { get { return obj.Id; } set { obj.Id = value; } }
        public string Title { get { return obj.Title; } set { obj.Title = value; } }
        public object this[string key] {
            get { return ((IDictionary<string,object>)obj)[key]; }
            set { ((IDictionary<string,object>)obj)[key] = value; }
        }
    }
