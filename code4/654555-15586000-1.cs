    public static IEnumerable<string> YourMethod()
    {
         string gowtham = "test1,test2,test3";
         string[] mysamples = gowtham.Split(',');
         List<string> senum = new List<string>();
    
         foreach ( string s in mysamples )
         {
             senum.Add(s);
         }
    
         return senum as IEnumerable<string>;
    }
