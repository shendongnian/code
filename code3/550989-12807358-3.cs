      public PokeContext : DbContext
        {
        DbSet<Pokemon> Kanto {get;set;}
        DbSet<PokeAbility> Abilies {get; set;}
        DbSet<PokeType> Types {get; set;}
        }
