        public class LockedKeyCollection : System.Collections.Hashtable
        {
            public override void Add(object key, object value)
            {
                //do nothing or throw exception?
            }
            //and so on to Add* and Remove*
            public override object this[object i]
            {
                get
                {
                    return base[i];
                }
                set
                {
                    //do nothing or throw exception?
                }
            }
        }
