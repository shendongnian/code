     [TestMethod]
        public void ToHex()
        {
            string str = "1234A";
            var result = str.Select(s => string.Format("0x{0:X8}", ((byte)s).ToString("X2")));
           foreach (var item in result)
           {
               Debug.WriteLine(item);
           }
       
        }
