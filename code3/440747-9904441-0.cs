    public class X
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Y
    {
        public int Id { get; set; }
        public int Age { get; set; }
    }
    List<X> xList = new List<X>();
    xList.Add(new X() { Id = 0, Name = "a" });
    xList.Add(new X() { Id = 1, Name = "b" });
    xList.Add(new X() { Id = 2, Name = "c" });
    xList.Add(new X() { Id = 3, Name = "d" });
    List<Y> yList = new List<Y>();
    yList.Add(new Y() { Id = 0, Age=20 });
    yList.Add(new Y() { Id = 2, Age = 30 });
    yList.Add(new Y() { Id = 4, Age = 40 });
    var xQuery = from x in xList
                 select new
                 {
                     Id = x.Id                             
                 };
    var yQuery = from y in yList
                 select new
                 {
                      Id = y.Id
                             
                  };
            var un = xQuery.Except(yQuery).Union(yQuery);
