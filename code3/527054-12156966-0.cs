    public class CityDetailViewModel
    {
         ...
 
         public CityDetailViewModel()
         {
             this.MS = new List<long>();
         }
    }
    public ActionResult getGrid(string pk, string rk) {
        var sw = Stopwatch.StartNew();
        var vm = new CityDetailViewModel();
        ...
        vm.MS.Add(sw.ElapsedMilliseconds);
