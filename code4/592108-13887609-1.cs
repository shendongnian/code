    public class MovieRepository : Repository<Movie> {
    public MovieRepository(MovieContext context) : base(context) {}
    public override void Add(Movie entity) {
        foreach (var character in entity.Characters) {
            var person = Context.People.FirstOrDefault(p => p.Id == character.Person.Id);
            if (person != null) {
                character.Person = person;
            } else {
                personRepository.Save(character.Person)
            }
        }
        Context.Movies.Add(entity);
    }
