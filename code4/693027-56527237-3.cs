    using Microsoft.Extensions.Caching.Memory;
    namespace MySolution.Project.Controllers
    {
     public class MyController : Controller
     {
         private readonly IMemoryCache _cache;
        
         public LogController(IMemoryCache cache)
         {
            _cache = cache;
         }
         //rest of controller code here
      }
     }
