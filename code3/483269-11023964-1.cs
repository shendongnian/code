    public class DictRefList
    {
        private Dictionary<int, SomeRefClass> dict;
        private List<SomeRefClass> list; // your list implementation here
        public void DictRefList()
        {
            dict = new Dictionary<int, SomeRefClass>();
            list = new List<SomeRefClass>;
        }
        public void Add(int key, SomeRefClass val)
        { 
            dict.Add(key, val);
            list.Add(val);
        }
        public void Delete(int key, SomeRefClass val)
        {
            dict.Remove(key);
            list.Remove(val);
        }
        public void Update(int key, SomeRefClass val)
        {
            dict[key] = val;
            list.Add(val); // do what is necessary to keep it valid and have no duplicate value
        }
    }
