    [Route("/api/customers", "GET")]  //works okay
    [Route("/api/customers/page/{Page}", "GET")] //doesn't work
    [Route("/api/customers/page/{Page}/size/{PageSize}", "GET")] //doesn't work
    public class Customers
    {
        public Customers() { Page = 1; PageSize = 20; } //by default 1st page 20 records
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    //----------------------------------------------------
    public class CustomersService : Service
    {
        public dynamic Get(Customers req)
        {
            var paths = ((ServiceController) base.GetAppHost().Config.ServiceController).RestPathMap.Values.SelectMany(x => x.Select(y => y.Path)); //find all route paths
            var list = String.Join(", ", paths);
            return new { Page = req.Page, PageSize = req.PageSize, Paths = list };
        }
    }
 
