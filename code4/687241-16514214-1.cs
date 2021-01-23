    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                MongoCollection<Tick> coll =
                    new MongoClient("mongodb://11.11.11.11/test").GetServer()
                                                                    .GetDatabase("test")
                                                                    .GetCollection<Tick>("tix");
                var group = new BsonDocument
                    {
                        {
                            "$group",
                            new BsonDocument
                                {
                                    {
                                        "_id",  "$CompanyName"
                                    },
                                    {
                                        "LastViewed", new BsonDocument
                                            {
                                                {
                                                    "$max", "$Viewed"
                                                }
                                            }
                                    }
                                }
                        }
                    };
                foreach (
                    var t in
                        coll.Aggregate(group)
                            .ResultDocuments.OrderByDescending(tick => tick["LastViewed"])
                            .Take(3))
                {
                    Console.WriteLine("{0} last viewed {1}", t["_id"], t["LastViewed"]);
                }
                Console.Read();
            }
        }
        public class Tick
        {
            public string Id { get; set; }
            public string Ticker { get; set; }
            public string CompanyName { get; set; }
            public string Viewed { get; set; }
        }
    }
