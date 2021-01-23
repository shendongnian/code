     [TestMethod]
        public void ToHex()
        {
            string str = "1234A";
            var result = str.Select(s => ((byte)s).ToString("X2"));
           foreach (var item in result)
           {
               Debug.WriteLine(item);
           }
       
        }
