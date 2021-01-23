    using ServiceStack.Redis;
    using ServiceStack.Redis.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Redis.Extensions;
    
    namespace RedisTestsWithBooksleeve.Controllers
    {
        public class SampleEvent
        {
            public int ID { get; set; }
            public string EntityID { get; set; }
            public string Name { get; set; }
        }
    
        public class ValuesController : ApiController
        {
            public IEnumerable<string> Get()
            {
                using (var redisClient = new RedisClient("localhost"))
                {
                    if (!redisClient.ContainsKey("Meds25"))
                    {
    
                        redisClient.GetFromCache<IEnumerable<SampleEvent>>("Meds25", () => { 
                                            
                            var medsWithID25 = new List<SampleEvent>();
                            medsWithID25.Add(new SampleEvent() { ID = 1, EntityID = "25", Name = "Digoxin" });
                            medsWithID25.Add(new SampleEvent() { ID = 2, EntityID = "25", Name = "Aspirin" });
    
                            return medsWithID25;
    
                        }, TimeSpan.FromSeconds(5));
                    }
    
                }
                
                return new string[] { "1", "2" };
            }
    
            public SampleEvent Get(int id)
            {
                using (var redisClient = new RedisClient("localhost"))
                {
                    IEnumerable<SampleEvent> events = redisClient.GetFromCache<IEnumerable<SampleEvent>>("Meds25", () =>
                    {
    
                        var medsWithID25 = new List<SampleEvent>();
                        medsWithID25.Add(new SampleEvent() { ID = 1, EntityID = "25", Name = "Digoxin" });
                        medsWithID25.Add(new SampleEvent() { ID = 2, EntityID = "25", Name = "Aspirin" });
    
                        return medsWithID25;
    
                    }, TimeSpan.FromSeconds(5));
    
                    if (events != null)
                    {
                        return events.Where(m => m.ID == id).SingleOrDefault();
                    }
                    else
                        return null;
                }
            }
        }
    }
