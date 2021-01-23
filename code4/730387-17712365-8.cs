    interface IAnimalService { IAnimal SearchForAnimals(IAnimalSearchOptions opts); }
    
    interface IAnimalService<out TAnimal, in TOptions> : IAnimalService
        where TAnimal : IAnimal
        where TOptions : IAnimalSearchOptions {
        TAnimal SearchForAnimals(TOptions opts);
    }
    
    class MammalService : IAnimalService<Mammal, MammalSearchOptions>
    {
        Mammal SearchForAnimals(MammalSearchOptions opts) { ... }
    
        IAnimal IAnimalService.SearchForAnimals(IAnimalSearchOptions opts)
        {
            return this.SearchForAnimals((MammalSearchOptions)opts);
        }
    }
    
....
    var dict = new Dictionary<string, IAnimalService> { "Dog", new MammalService() };
