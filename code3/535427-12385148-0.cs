        Blah("\t");
        private static void Blah(string s)
        {
            var chars = s.ToCharArray();
            Debug.Assert(chars.Length == 1);
            var parts = "blah\tblah\thello".Split(chars);            
            Debug.Assert(parts.Length == 3);
        }
