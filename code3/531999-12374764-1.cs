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
            [BsonIgnoreExtraElements]
            public class WidgetCollection
            {
                [BsonId]
                public int AccountId { get; set; }
                public ReadOnlyCollection<Widget> Widgets { get; set; }
            }
    
    
            [BsonIgnoreExtraElements]
            [BsonDiscriminator(RootClass = true)]
            public class Widget
            {
                public string Title { get; set; }
                public int Position { get; set; }
                public bool IsActive { get; set; }
            }
    
            static void Main(string[] args)
            {
                var server = MongoServer.Create();
                server.Connect();
    
                var db = server.GetDatabase("widgettest");
                var collection = db.GetCollection<WidgetCollection>("widgets");
                collection.Drop();
    
                var widgets = new WidgetCollection();
                var widget1 = new Widget { Title = "One", Position = 0, IsActive = true };
                var widget2 = new Widget { Title = "Two", Position = 1, IsActive = true };
                var widget3 = new Widget { Title = "Three", Position = 2, IsActive = false };
                widgets.Widgets = new List<Widget> { widget1, widget2, widget3 }.AsReadOnly();
    
                collection.Save(widgets);
    
                var command = new CommandDocument(
                    new BsonElement("aggregate", "widgets"),
                    new BsonElement("pipeline", new BsonArray(new [] {
                        new BsonDocument(
                            new BsonElement("$project", new BsonDocument("Widgets", 1)))})));
    
                var response = db.RunCommand(command);
                var rawDoc = response.Response["result"].AsBsonArray.SingleOrDefault().AsBsonDocument;
    
                var doc = BsonSerializer.Deserialize<WidgetCollection>(rawDoc);
    
                //Console.ReadKey();
            }
        }
    }
