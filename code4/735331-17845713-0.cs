      [TestMethod]
      public void TestBytToString()
      {
         byte[] bytArray = new byte[256];
         ushort[] usArray = new ushort[256];
         for (int i = 0; i < bytArray.Length; i++)
         {
            bytArray[i] = (byte)i;
            
         }
         
         string x = System.Text.Encoding.Default.GetString(bytArray);
         for (int i = 0; i < x.Length; i++)
         {
            int y = System.Text.Encoding.Default.GetBytes(x.Substring(i, 1))[0];
            Assert.AreEqual(i, y);
         }
      }
