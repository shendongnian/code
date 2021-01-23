        public IEnumerable<string> Method1(string name)
        {
            if (name.Equals("xyz"))
            {
                throw new Exception("xyz are not allow");
            }
            var list = new List<string>();
            list.Add("ABC");
            return list;
            
            //yield return "ABC";
        }
