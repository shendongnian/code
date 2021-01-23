    public class IncrementDictionary : Dictionary<int, object>
    {
        private bool[] usedKeys = new bool[1000];
        public new void Add(int key, object value)
        {
            base.Add(key, value);
            usedKeys[key] = true;
        }
        public new void Clear()
        {
            base.Clear();
            usedKeys = new bool[1000];
        }
        public new object this[int key] 
        {
            get
            {
                return base[key];
            }
            set
            {
                base[key] = value;
                usedKeys[key] = true;
            }
        }
        public new bool Remove(int key)
        {
            usedKeys[key] = false;
            return base.Remove(key);
        }
        public int AddNext(object anObj)
        {
            int newKey = -1;
            for (int i = 1; i < 1000; i++)
                if (!usedKeys[i])
                {
                    newKey = i;
                    break;
                }
            if (newKey > 0)
                this.Add(newKey, anObj);
            return newKey;
        }
    }
