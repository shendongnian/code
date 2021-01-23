     public class Test
        {
           // your all return properties goes here
           public string Typ;
        }
    
    public class Test2
    {
       public List<Test> GetRequireData()
       {
            var Uom = SpOpDcontx.Ptr_UOMs.Select(c => new Test()
                       {
                        Typ = c.UM_Typ)
                       })
                       .Distinct();
             return Uom.ToList<Test>();
       }
    }
