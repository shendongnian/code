    public class YourController : Controller
    {
         private readonly IPageHistoryBuilder pageHistoryBuilder;
         public YourController(IPageHistoryBuilder pageHistoryBuilder)
         {
             this.pageHistoryBuilder = pageHistoryBuilder;
         }
    }
