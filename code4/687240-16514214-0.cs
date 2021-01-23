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
                                        "_id", new BsonDocument
                                            {
                                                {
                                                    "CompanyName", "$CompanyName"
                                                }
                                            }
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
                var res = coll.Aggregate(group);
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
