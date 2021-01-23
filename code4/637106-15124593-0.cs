    public IEnumerable<Dog> Dogs { get ; set ; }
    public IEnumerable<Dog> FindDogsNotWalkedRecently( DateTime referenceDate )
    {
        return Dogs.Where( dog => dog.LastWalkedAt < referenceDate ) ;
    }
