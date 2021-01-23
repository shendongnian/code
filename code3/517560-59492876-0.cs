    static void Main(string[] args)
        {
           string myCC = "4556364607935616";
           string myMasked = Maskify(myCC);
           Console.WriteLine(myMasked);
        }        
        
    public static string Maskify(string cc)
        {
           int len = cc.Length;
           if (len <= 4)
              return cc;
        
           return cc.Substring(len - 4).PadLeft(len, '#');
        }
