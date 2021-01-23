    public class A
    {
        private Dictionary<string, string> _dict = new Dictionary<string, string>();
        public void Add_dict(string name, string add)
        {
            _dict.Add(name, add);
        }
        public Dictionary<string, string> Return_dictionary()
        {
            return _dict; 
        }
    }
