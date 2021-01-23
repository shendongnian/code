    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    namespace TestConsole_Source
    {
        class Program
        {
            public class MyDocument
            {
                public ObjectId Id { get; set; }
    
                [BsonRequired]
                public string Name { get; set; }
    
                [BsonRequired]
                public ObjectId LayoutId { get; set; }
            }
    
            static void Main(string[] args)
            {
                var server = MongoServer.Create();
                server.Connect();
    
                var db = server.GetDatabase("docstest");
                var collection = db.GetCollection<MyDocument>("docs");
                collection.Drop();
    
                var doc = new MyDocument
                {
                    Name = "Test",
                    LayoutId = ObjectId.GenerateNewId()
                };
    
                collection.Save(doc);
    
                var foundDoc = collection.FindOne();
                //Console.ReadKey();
            }
        }
    }
