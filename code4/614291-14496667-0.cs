        private static void Main()
        {
            List<tmp> lst = new List<tmp>();
            Dictionary<decimal, string> myDict = new Dictionary<decimal, string>();
            foreach (tmp temp in lst)
            {
                myDict.Add(temp.Id + temp.Index, string.Format("{0}{1}", temp.Name, temp.LName));
            }
            Hashtable table = new Hashtable(myDict);
        }
