    char[] allowedChars = Enumerable.Range('A', 26).Concat(Enumerable.Range('a', 26))
      .Select(i => (char)i).ToArray();
    [TestMethod]
    public void Test()
    {
      Assert.AreEqual("A", Algo(0, 1));
      Assert.AreEqual("AB", Algo(1, 2));
      Assert.AreEqual("ACE", Algo(2, 3));
      Assert.AreEqual("ADGJ", Algo(3, 4));
      Assert.AreEqual("AEIMQ", Algo(4, 5));
    }
    public string Algo(int n, int len)
    {
      StringBuilder sb = new StringBuilder();
      int nextCharIndex = 0;
      for (int f = 0; f < len; f++)
      {
        sb.Append(allowedChars[nextCharIndex]);
        //the `%`, or mod, here wraps around the next character back to upper case
        nextCharIndex = (nextCharIndex + n) % allowedChars.Length;
      }
      return sb.ToString();
    }
