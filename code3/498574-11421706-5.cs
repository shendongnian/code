using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Program
{
	public static void Main()
	{
		
		var movie1 = new Movie { Id = 1, Title = "Godzilla" };
		var movie2 = new Movie { Id = 2, Title = "Iron Man" };
    	using (var context = new MovieDb())
    	{
			/*
			context.Database.Log = (s) => {
				Console.WriteLine(s);
			};
            */
			
			Console.WriteLine("========= Start Add: movie1 ==============");
			context.Movies.Add(movie1);
	        context.SaveChanges();
			Console.WriteLine("========= END Add: movie1 ==============");
			// LET EF CREATE ALL THE SCHEMAS AND STUFF THEN WE CAN TEST
			context.Database.Log = (s) => {
				Console.WriteLine(s);
			};
			Console.WriteLine("========= Start SELECT FIRST movie ==============");
			var movie1a = context.Movies.First();
			Console.WriteLine("========= End SELECT FIRST movie ==============");
			
			Console.WriteLine("========= Start Attach Movie2 ==============");
			context.Movies.Attach(movie2);
			Console.WriteLine("========= End Attach Movie2 ==============");
			
			Console.WriteLine("========= Start SELECT Movie2 ==============");
			var movie2a = context.Movies.FirstOrDefault(m => m.Id == 2);
			Console.WriteLine("========= End SELECT Movie2 ==============");
			Console.Write("Movie2a.Id = ");
			Console.WriteLine(movie2a == null ? "null" : movie2a.Id.ToString());
		}
	}
	public class MovieDb : DbContext
    {
        public MovieDb() : base(FiddleHelper.GetConnectionStringSqlServer()) {}
        public DbSet<Movie> Movies { get; set; }
    }
    public class Movie
    {
		[Key]
	    [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
If attach makes any DB calls, we will see them between the *Start Attach Movie2* and *End Attach Movie2*.  We also verify that the documentation that states:
> **Remarks**
> Attach is used to repopulate a context with an entity that is known to already exist in the database.
> SaveChanges will therefore not attempt to insert an attached entity into the database because it is assumed to already be there.
After attaching the movie2, we can attempt to select it from the DB.  It should not be there (because EF only assumes it is there).
> ========= Start Add: movie1 ==============
> ========= END Add: movie1 ==============
> ========= Start SELECT FIRST movie ==============
> Opened connection at 1/15/2020 5:29:23 PM +00:00
> SELECT TOP (1) 
>  [c].[Id] AS [Id], 
>  [c].[Title] AS [Title]
>  FROM [dbo].[Movies] AS [c]
> -- Executing at 1/15/2020 5:29:23 PM +00:00
> -- Completed in 23 ms with result: SqlDataReader
> Closed connection at 1/15/2020 5:29:23 PM +00:00
> ========= End SELECT FIRST movie ==============
> ========= Start Attach Movie2 ==============
> ========= End Attach Movie2 ==============
> ========= Start SELECT Movie2 ==============
> Opened connection at 1/15/2020 5:29:23 PM +00:00
> SELECT TOP (1) 
> [Extent1].[Id] AS [Id], 
> [Extent1].[Title] AS [Title]
> FROM [dbo].[Movies] AS [Extent1]
> WHERE 2 = [Extent1].[Id]
> -- Executing at 1/15/2020 5:29:23 PM +00:00
> -- Completed in 2 ms with result: SqlDataReader
> Closed connection at 1/15/2020 5:29:23 PM +00:00
> ========= End SELECT Movie2 ==============
> Movie2a.Id = null
So no SQL called during the attach, no error message attaching it, and it's not in the database.
