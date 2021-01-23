        public class LockedDictionary : Dictionary<string, string>
        {
            public override void Add(string key, string value)
            {
                //...
            }
            //and so on to Add* and Remove*
            public override string this[string i]
            {
                get
                {
                    return base[i];
                }
                private set
                {
                    //...
                }
            }
        }
