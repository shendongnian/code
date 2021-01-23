    public class FooWithFilteredBarResult // replace with whatever name you like
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Bar> { get; set; }
    }
    List<FooWithFilteredBarResult> results = 
        (from f in db.Foos
         select new FooWithFilteredBarResult 
         {
             Id = f.Id,
             Name = f.Name,
             Bars = f.Bars.Where(b => b.Age >= 5 && b.Age <= 25)
         })
        .ToList();
