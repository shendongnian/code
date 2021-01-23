    class MyList<T> : List<T>
    {
        static List<object> superlist;
        public string name;
        ~MyList() {
            if (superlist != null)
            superlist.Remove(this);
        }
        public MyList(string name)
            : base() {
            init(name);
        }
        public MyList(string name, int cap)
            : base(cap) {
            init(name);
        }
        public MyList(string name, IEnumerable<T> IE)
            : base(IE) {
            init(name);
        }
        void init(string name) {
            if (superlist == null)
                superlist = new List<object>();
            this.name = name;
            superlist.Add(this);
        }
        public static void AddToListByName(T add, string listName) {
            for (int i = 0; i < superlist.Count; i++) {
                if (superlist[i].GetType().GenericTypeArguments[0] == add.GetType() && ((MyList<T>)(superlist[i])).name == listName) {
                    ((MyList<T>)(superlist[i])).Add(add);
                    return;
                }
            }
            throw new Exception("could not find the list");
        }
    }
