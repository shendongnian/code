    void Main()
    {
      Dictionary<Enum,object> dict = new Dictionary<Enum,object>();
      dict.Add(asdf.lkj,null);
      dict.Add(qwer.oiu,null);
      Console.WriteLine(dict.ContainsKey(qwer.oiu));
      Console.WriteLine(dict.ContainsKey(asdf.lkj));
      Console.WriteLine(dict.ContainsKey(qwer.zxcv));
    }
    
    enum asdf {
      lkj
    }
    
    enum qwer {
      oiu,
      zxcv
    }
