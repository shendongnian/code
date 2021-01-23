    class Program {
       public string GetData(){
           return "Hello";
       }
       public IObservable<string> GetDataObservable(){
           return Observable
                .Interval(TimeSpan.FromSeconds(15))
                .Take(1)
                .Select(()=>GetData());
       }
       static void Main(string[]args){
           var s = GetDataObservable().Wait();
       }
    }
