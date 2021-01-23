        public static List<T> DifferentObjects<T>(List<T> t, List<T> t2) where T : class
        {
            var diff = new List<T>();
            if (t != null && t2 != null)
            {
                foreach (T t1 in t)
                {
                    var state = false;
                    foreach (T t3 in t2.Where(t3 => EqualsObject(t1,t3)))
                    {
                        state = true;
                    }
                    if (!state)
                    {
                        diff.Add(t1);
                    }
                }
            }
            return diff;
        }
