    public class Pokemon
    {
    int Id {get; set;}
    ICollection<PokeAbility> Abilities {get; set;}
    ICollection<PokeType> Types {get; set;}
    }
