    public ActionResult Kittens() // some parameters might be here
    {
       	using(var service = new KittenService())
    	{
        	var result =  service.GetFluffyKittens();  
    		return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
    public class KittenService : IDisposable
    {
    	public IEnumerable<Kitten> GetFluffyKittens()
    	{
    		using(var db = new KittenEntities()){ // db can also be injected,
           		return db.Kittens // this explicit query is here
                          .Where(kitten=>kitten.fluffiness > 10) 
                          .Select(kitten=>new {
                                Name=kitten.name,
                                Url=kitten.imageUrl
                          }).Take(10); 
       		}
    	}
    }
