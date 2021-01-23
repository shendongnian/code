    [SessionState(SessionStateBehavior.ReadOnly)]
        public class HomeController : Controller
        {
            static readonly ManualResetEvent Starter = new ManualResetEvent(false);
            public ActionResult Index()
            {
                return View();
            }
    
            public String RiseServerEvent()
            {
                Starter.Set();
                return "";
            }
    
            public async Task<String> WaitForServerEvent()
            {
                string contents = null;
                var result = Task.Factory.StartNew(() =>
                {
                    var reg = ThreadPool.RegisterWaitForSingleObject
                                 (Starter, (state, @out) =>
                                 {
                                     contents = DateTime.Now.TimeOfDay.ToString();
                                 }, "Some Data", -1, true);
    
                    Starter.WaitOne(10000);   
                    contents = DateTime.Now.TimeOfDay.ToString();
                });
                await result;
                return contents;
            }
    
        }
