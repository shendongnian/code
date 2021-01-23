     [TestMethod]
        public void ToHex()
        {
            string str = "1234";
           var result= str.Select(s=>string.Format("0x{0:x8}",s));
           foreach (var item in result)
           {
               Debug.WriteLine(item);
           }
       
        }
