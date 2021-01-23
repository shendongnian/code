        public class LockedDictionary : System.Collections.Hashtable
        {
            //Access modifier to allow only in-assembly operations
            internal override void Add(int key, object value)
            {
                base.Add(key, value);
            }
            //and so on to Add* and Remove*
            public override object this[object i]
            {
                get
                {
                    return base[i];
                }
                private set
                {
                    base[i] = value;
                }
            }
        }
