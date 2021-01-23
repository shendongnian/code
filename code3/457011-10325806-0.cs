    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Bson.IO;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.Conventions;
    using MongoDB.Bson.Serialization.IdGenerators;
    using MongoDB.Bson.Serialization.Options;
    using MongoDB.Bson.Serialization.Serializers;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Wrappers;
    
    namespace MongoDB
    {
        class Program
        {
            static void Main(string[] args)
            {
                MongoServer server;
                MongoDatabase moviesDb;
    
                server = MongoServer.Create();
                moviesDb = server.GetDatabase("movies_db");
    
                //Create some data
                var movie1 = new Movie { Title = "Indiana Jones and the Raiders of the Lost Ark", Year = "1981" };
                movie1.AddActor("Harrison Ford");
                movie1.AddActor("Karen Allen");
                movie1.AddActor("Paul Freeman");
    
                var movie2 = new Movie { Title = "Star Wars: Episode IV - A New Hope", Year = "1977" };
                movie2.AddActor("Mark Hamill");
                movie2.AddActor("Harrison Ford");
                movie2.AddActor("Carrie Fisher");
    
                var movie3 = new Movie { Title = "Das Boot", Year = "1981" };
                movie3.AddActor("Jürgen Prochnow");
                movie3.AddActor("Herbert Grönemeyer");
                movie3.AddActor("Klaus Wennemann");
    
                //Insert the movies into the movies_collection
                var moviesCollection = moviesDb.GetCollection<Movie>("movies_collection");
                //moviesCollection.Insert(movie1);
                //moviesCollection.Insert(movie2);
                //moviesCollection.Insert(movie3);
    
                var query = Query.EQ("Year","1981");
    
                var movieFound = moviesDb.GetCollection<Movie>("movies_collection").Drop();
    
            }
    
    
    
        }
    
    
    }
