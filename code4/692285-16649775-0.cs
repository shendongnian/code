    public class Result {
      public int Hits = 0;
      public string Name = "";
    
      public void IncreaseHits() {
        this.hits++;
      }
    
      public Result(String name) {
        this.name = name;
      }
    }
    class Program {
       public Dictionary<string, Result> MyCache; //what structure to use?
       public main() {
        MyCache.Add("My result 1", new Result("My result 1"));
        MyCache.Add("My result 2", new Result("My result 2"));
        MyCache.Add("My result 3", new Result("My result 3"));
        MyCache["My result 2"].IncreaseHits();
        MyCache["My result 2"].IncreaseHits();
        MyCache["My result 3"].IncreaseHits();
       foreach(Result result in MyCache.OrderByDesc(x => x.Hits)) {
          Console.Write(result.Name + " - hits " + result.Hits);
       }
      }
    }
