        public bool ContainsFoo(string s)
        {
            bool result = true;
            if (s.IndexOf("Foo") > 0)
            {
                result = false;
            }
            else if (s.LastIndexOf("Foo") > 0)
            {
                result = false;
            }
            return result;
        }
