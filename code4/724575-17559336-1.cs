    namespace MyProject.Web.Controllers
    {
       public class MyController : Controller
       {
          private readonly IKittenService _kittenService ;
    
          public MyController(IKittenService kittenService)
          {
             _kittenService = kittenService;
          }
    
          public ActionResult Kittens()
          {
              // var result = _kittenService.GetLatestKittens(10);
              // Return something.
          }
       }  
    }
    
    namespace MyProject.Domain.Kittens
    {
       public class Kitten
       {
          public string Name {get; set; }
          public string Url {get; set; }
       }
    }
    
    namespace MyProject.Services.KittenService
    {
       public interface IKittenService
       {
           IEnumerable<Kitten> GetLatestKittens(int fluffinessIndex=10);
       }
    }
    
    namespace MyProject.Services.KittenService
    {
       public class KittenService : IKittenService
       {
          public IEnumerable<Kitten> GetLatestKittens(int fluffinessIndex=10)
          {
             using(var db = new KittenEntities())
             {
                return db.Kittens // this explicit query is here
                          .Where(kitten=>kitten.fluffiness > 10) 
                          .Select(kitten=>new {
                                Name=kitten.name,
                                Url=kitten.imageUrl
                          }).Take(10); 
             }
          }
       }
    }
