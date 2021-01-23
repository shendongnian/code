    private void PrintDiff()
    {
            public Dictionary<string, Model> dictionary = new Dictionary<string, Model>();
            
            foreach (var entry in Array1)
            {
                dictionary.Add(entry, (new Model()).Add(entry, "Array1"));
            }
            foreach (var entry in Array2)
            {
                if (!dictionary.ContainsValue(entry))
                     dictionary.Add(entry, (new Model()).Add(entry, "Array2"));
            }
            foreach (var entry in Array3)
            {
                if (!dictionary.ContainsValue(entry))
                     dictionary.Add(entry, (new Model()).Add(entry, "Array3"));
            }
            //now print 
            foreach (var model in dictionary)
            {
                model.ToString();
            }
        }
    public class Model
    {
        public Model()
        {
            Dictionary = new Dictionary<string, string>();
        }
        private Dictionary<string, string> Dictionary
        {
            get;
            set;
        }
        public bool ContainsEntry(string entry)
        {
            return Dictionary.ContainsValue(entry);
        }
        public void Add(string entry, string arrayName)
        {
            Dictionary.Add(arrayName, entry);
        }
        public override string ToString()
        {
            return "FORMATED AS YOU WANT THEM";
        }
    }
