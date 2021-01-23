void Main()
{
	var data = DataAccess.GetData();
	var res = 
		from m in data.Movies
		join ma in data.MovieActor on m.Id equals ma.MovieId into mma
		from ma in mma.DefaultIfEmpty()
		join p in data.People on (ma == null ? 0 : ma.ActorId) equals p.Id into pma
		from p in pma.DefaultIfEmpty()
		orderby m.Name
		select new {
			Movie = m.Name,
			Actor = p != null ? p.Name + " as " + ma.Name : ""
		};
	foreach (var el in res)
	{
		Console.WriteLine($"{el.Movie} - {el.Actor}");
	}
}
public class DataAccess
{
	public static Data GetData()
	{
		var list = new Data
		{
			Movies = new List<Movie>{
			 new Movie{ Id = 1, Name= "Raiders of the Lost Ark", Year = 1981},
			 new Movie{ Id = 2, Name= "Blade Runner", Year = 1982},
			 new Movie{ Id = 3, Name= "Star Wars: Episode IV - A New Hope", Year = 1977},
			 new Movie{ Id = 4, Name= "Total Recall", Year = 1990},
			 new Movie{ Id = 5, Name= "The Fugitive", Year = 1993},
			 new Movie{ Id = 6, Name= "Men in Black", Year = 1997},
			 new Movie{ Id = 7, Name= "U.S. Marshals", Year = 1998},
			 new Movie{ Id = 8, Name= "Batman", Year = 1989},
			 new Movie{ Id = 9, Name= "A Few Good Men", Year = 1992},
			 new Movie{ Id = 10, Name= "Tropic Thunder", Year = 2008},
			 new Movie{ Id = 11, Name= "Minority Report", Year = 2002},
			 new Movie{ Id = 12, Name= "The Fifth Element", Year = 1997},
			 new Movie{ Id = 13, Name= "District 9", Year = 2009},
			 new Movie{ Id = 14, Name= "12 Monkeys", Year = 1995},
			},
			People = new List<Person>{
		 		new Person{ Id = 1, Name = "Harrison Ford"},
		 		new Person{ Id = 2, Name = "Tommy Lee Jones"},
		 		new Person{ Id = 3, Name = "Will Smith"},
		 		new Person{ Id = 4, Name = "Michael Keaton"},
		 		new Person{ Id = 5, Name = "Will Smith"},
		 		new Person{ Id = 6, Name = "Jack Nicholson"},
		 		new Person{ Id = 7, Name = "Tom Cruise"}
		 	},
			MovieActor = new List<MovieActor>{
				new MovieActor{ MovieId = 1, ActorId = 1, Name = "Indy"},
				new MovieActor{ MovieId = 2, ActorId = 1, Name = "Rick Deckard"},
				new MovieActor{ MovieId = 3, ActorId = 1, Name = "Han Solo"},
				new MovieActor{ MovieId = 5, ActorId = 1, Name = "Dr. Richard Kimble"},
				new MovieActor{ MovieId = 5, ActorId = 2, Name = "Samuel Gerard"},
				new MovieActor{ MovieId = 6, ActorId = 2, Name = "Kay"},
				new MovieActor{ MovieId = 7, ActorId = 2, Name = "Samuel Gerard"},
				new MovieActor{ MovieId = 6, ActorId = 3, Name = "Jay"},
				new MovieActor{ MovieId = 8, ActorId = 4, Name = "Batman / Bruce Wayne"},
				new MovieActor{ MovieId = 8, ActorId = 6, Name = "Joker / Jack Napier"},
				new MovieActor{ MovieId = 9, ActorId = 6, Name = "Col. Nathan R. Jessep"},
				new MovieActor{ MovieId = 9, ActorId = 7, Name = "Lt. Daniel Kaffee"},
				new MovieActor{ MovieId = 10, ActorId = 7, Name = "Les Grossman"},
				new MovieActor{ MovieId = 11, ActorId = 7, Name = "Chief John Anderton"}
			}
			
		};
		return list;
	}
}
public class Data
{
	public List<Movie> Movies = new List<Movie>();
	public List<Person> People = new List<Person>();
	public List<MovieActor> MovieActor = new List<MovieActor>();
}
public class Person
{
	public int Id { get; set; }
	public string Name { get; set; }
}
public class Movie
{
	public int Id { get; set; }
	public string Name {get; set;}
	public int Year { get; set; }
}
public class MovieActor
{
	public int MovieId { get; set; }
	public int ActorId { get; set; }
	public string Name { get; set; } // appearance as
}
