    As.SelectMany(a => a.myObjects, (aa, mo) => new R {Tp = aa, Mi = mo as MyInfo})
      .Where(r => r.Mi != null && r.Mi.someProp == 1)
      //.Distinct(new Comparer<R>((r1, r2) => r1.Tp.Equals(r2.Tp))) 
      // If you need only one (first) MyInfo from a ThirdParty 
      // You don't need R if you're not going to use Distinct, just use an anonymous
      .SelectMany(r => r.Mi.cs, (rr, c) => new {a = rr.Tp, c})
      .Where(ao => ao.c.data == 1)      
   
    public class R {
        public ThirdParty Tp;
        public MyInfo Mi;
    }
