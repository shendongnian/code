    using System;
    using Db4objects.Db4o;
    
    namespace Db4oSample
    {
    	class Person
    	{
    		public string Name { get; set; }
    		public Person Mother { get; set; }
    
    		public override string ToString()
    		{
    			return Name + (Mother != null ? "(" + Mother + ")" : "");
    		}
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var grandMother = new Person {Name = "grandma"};
    			var mother = new Person {Name = "mother", Mother = grandMother };
    			var son = new Person {Name = "son", Mother = mother};
    			
    			using(var db = Db4oEmbedded.OpenFile("database.odb")) // Closes the db after storing the object graph
    			{
    				db.Store(son);
    			}
    
    			using(var db = Db4oEmbedded.OpenFile("database.odb"))
    			{
    				var result = db.Query<Person>(p => p.Name == "son");
    				if (result.Count != 1)
    				{
    					throw new Exception("Expected 1 Person, got " + result.Count);
    				}
    
    				Console.WriteLine(result[0]);
    			}
    		}
    	}
    }
