    public class Sums
    {
       public int Sum1{get;set;}
       public int Sum2{get;set;}
       public int Sum3{get;set;}
    }
    var list = db.YourClass.Where(x=>x.fl1==cn1 && x.f12==cn2).Select(y => 
                                    new Sums{ 
                                        Sum1 = y.Sum(z=>z.fl1),
                                        Sum2 = y.Sum(z=>z.fl2),
                                        Sum3 = y.Sum(z=>z.fl3)
                                    }).ToList();
