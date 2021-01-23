        public static void MyMethod(object obj)
        {
            if (typeof(IDictionary).IsAssignableFrom(obj.GetType()))
            {
                IDictionary idict = (IDictionary)obj;
                Dictionary<string, string> newDict = new Dictionary<string, string>();
                
                foreach (object key in idict.Keys)
                {
                    newDict.Add(objToString(key), objToString(idict[key]));
                }
            }
            else
            {
                // My object is not a dictionary
            }
        }
        private static string objToString(object obj)
        {
            string str = "";
            if (obj.GetType().FullName == "System.String")
            {
                str = (string)obj;
            }
            else if (obj.GetType().FullName == "test.Testclass")
            {
                TestClass c = (TestClass)obj;
                str = c.Info;
            }
            return str;
        }
