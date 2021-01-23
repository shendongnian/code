    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    namespace Test.ConsoleApp
    {
    public class Sample
    {
        
        [BsonId]
        public ObjectId Id { get; private set; }
        public string Name { get; set; }
        public List<Token> Tokens { get; set; }
        public Sample()
        {
            Id = ObjectId.GenerateNewId();
            Tokens = new List<Token>();
        }
    }
    public class Token
    {
        public string Name { get; set; }
        public string Expiry { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var server = MongoServer.Create("mongodb://localhost/database?safe=true");
            var database = server.GetDatabase("test");
            var samplesCollection = database.GetCollection<Sample>("samples");
            Console.WriteLine("Creating Sample #1 ... ");
            var sample1 = new Sample();
            sample1.Name = "Sample #1";
            sample1.Tokens.Add(new Token() { Name = "Name #1", Expiry = "Today" });
            
            Console.WriteLine("Creating Sample #2 ... ");
            var sample2 = new Sample();
            sample2.Name = "Sample #2";
            sample2.Tokens.Add(new Token() { Name = "Name #2", Expiry = "Tomorrow" });
            sample2.Tokens.Add(new Token() { Name = "Name #3", Expiry = "Next Tuesday" });
            Console.WriteLine("Saving Sample #1 and #2 ... ");
            samplesCollection.Save(sample1);
            samplesCollection.Save(sample2);
            Console.WriteLine("Fetching Sample #1 and #2 ... ");
            var sampleOneFromDb = samplesCollection.AsQueryable<Sample>().Where(c => c.Name.Contains("Sample #1"));
            Console.WriteLine("Sample #1 From DB - {0}", sampleOneFromDb.ToJson());
            Console.ReadLine();
        }
      }
    }
