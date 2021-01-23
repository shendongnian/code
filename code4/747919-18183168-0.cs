      class Program
      {
        public class MyClass
        {
          public int qid { get; set; }
          public int cid { get; set; }
          public int gid { get; set; }
          public int sid { get; set; }
          public int cs { get; set; }
        }
    
        public class MyClassComaparer : IEqualityComparer<MyClass>
        {
    
          public bool Equals(MyClass x, MyClass y)
          {
            return x.qid == y.qid && x.gid == y.gid && x.sid == y.sid;
          }
    
          public int GetHashCode(MyClass obj)
          {
            return obj.qid;
          }
        }
    
        static void Main(string[] args)
        {
          var list = new List<MyClass>();
          list.Add(new MyClass() { qid = 1110, cid = 94, gid = 3, sid = 10, cs = 6 });
          list.Add(new MyClass() { qid = 1110, cid = 95, gid = 3, sid = 10, cs = 4 });
          list.Add(new MyClass() { qid = 1110, cid = 96, gid = 3, sid = 10, cs = 6 });
          list.Add(new MyClass() { qid = 1110, cid = 97, gid = 3, sid = 10, cs = 0 });
          list.Add(new MyClass() { qid = 1111, cid = 94, gid = 3, sid = 10, cs = 5 });
          list.Add(new MyClass() { qid = 1111, cid = 95, gid = 3, sid = 10, cs = 5 });
          list.Add(new MyClass() { qid = 1111, cid = 96, gid = 3, sid = 10, cs = 5 });
          list.Add(new MyClass() { qid = 1111, cid = 97, gid = 3, sid = 10, cs = 5 });
          list.Add(new MyClass() { qid = 1110, cid = 94, gid = 4, sid = 10, cs = 6 });
          list.Add(new MyClass() { qid = 1110, cid = 95, gid = 4, sid = 10, cs = 4 });
          list.Add(new MyClass() { qid = 1110, cid = 96, gid = 4, sid = 10, cs = 6 });
          list.Add(new MyClass() { qid = 1110, cid = 97, gid = 4, sid = 10, cs = 4 });
    
          var result = list.GroupBy(w => w, new MyClassComaparer()).Select(w => new
                      {
                        qid = w.Key.qid,
                        cid1cs = w.Where(e => e.cid == 94).Sum(e => e.cs),
                        cid2cs = w.Where(e => e.cid == 95).Sum(e => e.cs),
                        cid3cs = w.Where(e => e.cid == 96).Sum(e => e.cs),
                        cid4cs = w.Where(e => e.cid == 97).Sum(e => e.cs),                    
                        avg_cs = w.Average(i => i.cs),
                        gid = w.Key.gid,
                        sid = w.Key.sid
                      }).ToList();
    
          Console.ReadKey();
        }   
      }
