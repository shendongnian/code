	public class HomeController : Controller
	{
		private AutoResetEvent s_reset = new AutoResetEvent(false);
		public ActionResult Index()
		{
		    var state = new WorkerState() { HttpContextReference = System.Web.HttpContext.Current };
		    ThreadPool.QueueUserWorkItem(new WaitCallback(EmaiSenderWorker), state);
		    try
		    {
			s_reset.WaitOne();
		    }
		    finally
		    {
			s_reset.Close();
		    }
		    return View();
		}
		
		void EmaiSenderWorker(object state)
		{
		    var mystate = state as WorkerState;
		    if (mystate != null && mystate.HttpContextReference != null)
		    {
			System.Web.HttpContext.Current = mystate.HttpContextReference;
		    }
		    var mail = new UserMailer();
		    var msg = mail.Welcome();
		    msg.SendAsync();
		    s_reset.Set();
		}
		private class WorkerState
		{
		    public HttpContext HttpContextReference { get; set; }
		}
		
	}
