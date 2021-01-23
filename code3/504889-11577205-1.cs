        public static void MyMethod(object obj)
        {
            if (typeof(IDictionary).IsAssignableFrom(obj.GetType()))
            {
                IDictionary idict = (IDictionary)obj;
                Dictionary<string, string> newDict = new Dictionary<string, string>();
                foreach (object key in idict.Keys)
                {
                    newDict.Add(key.ToString(), idict[key].ToString());
                }
            }
            else
            {
                // My object is not a dictionary
            }
        }
