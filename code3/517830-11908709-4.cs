        public class LockedDictionary : Dictionary<string, string>
        {
            public override void Add(string key, string value)
            {
                //do nothing or log it somewhere
                //or simply change it to private
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
