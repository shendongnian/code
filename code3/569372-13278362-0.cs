    var flattenedShape =
      from movie in dataContractMovies
      from person in movie.Cast
      from characterName in person.Characters
      select new {Movie = movie, Person = person, CharacterName = characterName};
    
    
    List<Character> characters = new List<Character>();
    Dictionary<MovieDataContract, Movie> movieMap =
      new Dictionary<MovieDataContract, Movie>();
    Dictionary<PersonDataContract, Person> personMap =
      new Dictionary<PersonDataContract, Person>();
    
    foreach(var row in flattenedShape)
    {
      //have I seen this movie yet?
      if (!movieMap.ContainsKey(row.Movie))
      {
        movieMap.Add(row.Movie, new Movie() { Title = row.Movie.Title });
      }
    
      //have I seen this person yet?
      if (!personMap.ContainsKey(row.Person))
      {
        personMap.Add(row.Person, new Person() { Name = row.Person.Name });
      }
    
      //every character is unique.
      Character x = new Character() { Name = row.CharacterName };
      movieMap.Characters.Add(x);
      x.Movie = movieMap[row.Movie];
      personMap.Characters.Add(x);
      x.Person = personMap[row.Person];
      characters.Add(x);
    }
    
    //at this point, all the characters are in characters...
    // all the movies are in the movieMap.Values...
    // and all the persons are in the personMap.Values
