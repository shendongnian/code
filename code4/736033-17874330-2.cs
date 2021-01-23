    class Program {
       public string GetData(){
           return "Hello";
       }
       public string async GetDataAsync(){
           return await Observable
                .Interval(TimeSpan.FromSeconds(15))
                .Take(1)
                .Select(()=>GetData());
       }
       static void Main(string[]args){
           var s = GetDataAsync().Wait();
       }
    }
