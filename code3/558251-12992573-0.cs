    public IList<IAnimal> GetAnimals
    {
        var animals = new List<IAnimal>();
        foreach(var animal in db.Animals)
        {
            animals.add( // instantiate new animal here)
        }
        return animals;
    }
