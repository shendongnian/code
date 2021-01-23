    //using System.Linq;
    //using System.Reactive.Linq;
    //using System.Reactive.Threading.Tasks;
    
    var batches = alist.ToObservable().Buffer(size).ToList().ToTask().GetAwaiter().GetResult();
