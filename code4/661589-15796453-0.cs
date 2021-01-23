    public class PersonOrSuperHeroViewModel {
      private Person person;
      private SuperHero superHero;
      public PersonOrSuperHeroViewModel(Person personOrSuperHero) {
        if (personOrSuperHero is SuperHero) superHero = personOrSuperHero;
        person = personOrSuperHero;
      }
      public IsSuperHero { get { return superHero != null; } }
      ... // super-hero properties only work when IsSuperHero == true
    }
