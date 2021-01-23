     [TestMethod]
        public void ToHex()
        {
            string str = "1234A";
            var result = str.Select(s =>  string.Format("0x{0:X2}", ((byte)s)));
           foreach (var item in result)
           {
               Debug.WriteLine(item);
           }
       
        }
