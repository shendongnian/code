        [TestMethod]
        public void GenericTest()
        {
            Regex r = new Regex(".def.");
            Match mtch = r.Match("abcdefghijklmnopqrstuvwxyz", 0);
            for (int i = 0; i < 1000000; i++)
            {
                string a = mtch.Value;                  // 15.4%
                string b = mtch.ToString();             // 19.2%
                string c = mtch.Groups[0].Value;        // 23.1%
                string d = mtch.Groups[0].ToString();   // 38.5%
            }
        }
