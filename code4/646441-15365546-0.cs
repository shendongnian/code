    [Flags]
    public enum Animals 
    { 
        CatOne = 1, 
        CatTwo = 2, 
        CatThree = 4, 
        DogOne = 8, 
        DogTwo = 16,
        AllCats = Animals.CatOne | Animals.CatTwo | Animals.CatThree,
        AllDogs = Animals.DogOne | Animals.DogTwo 
    };
