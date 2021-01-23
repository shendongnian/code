    public class MyCacheClass {
       private Dictionary<string,Result> cache = new Dictionary<string, Result>();
       public void IncreaseHits(string name) {
          Result cached;
          if (!cache.TryGetValue(name, out cached)) {
            cached = cache.Add(new Result(name));
          }
          cached.IncreaseHits();
       }
       public string Add(string name) {
          // Need to block duplicates....
          cache.Add(name, new Result(name));
       }
       public IEnumerable<Result> SortDesc {
          get { return cache.Values.OrderByDesc(x => x.Hits); }
       }
    }
    class Program {
       MyCacheClass MyCache = new MyCacheClass();
       MyCache.Add("result1");
       MyCache.IncreaseHits("My result 2");
       MyCache.IncreaseHits("My result 2");
       MyCache.IncreaseHits("My result 3");
       foreach(Result result in MyCache.SorDesc) {
          Console.WriteLine(string.Format("{0} - hits {1}",result.Name,result.Hits);
       }
    }
