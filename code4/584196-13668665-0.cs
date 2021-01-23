    public class A
    {
       public List<B> Load(Collection coll)
       {
           List<B> list = (from x in coll select new B {Prop1 = x.title, Prop2 = x.dept}).ToList();
           return list;
       }
    }
