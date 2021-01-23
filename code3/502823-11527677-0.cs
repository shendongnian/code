    interface IAnimal
    {
        string Name { get; set; }
    }
    
    class Dog : IAnimal
    {
        public string Name { get; set; }
    }
    
    class Cat : IAnimal
    {
        public string Name { get; set; }
    }
    
    interface IAnimalEvaluator<T>
    {
        void Handle(IEnumerable<T> eval);
    }
    
    class AnimalHandler : IAnimalHandler<T> where T : IAnimal
    {
        public void Handle(IEnumerable<T> eval)
        {
            foreach (var t in eval)
            {
                Console.WriteLine(t.Name);
            }
        }
    }
    List<Dog> dogs = new List<Dog>() { new Dog() { Name = "Bill Murray" } };
    List<Cat> cats = new List<Cat>() { new Cat() { Name = "Walter Peck" } };
    
    AnimalHandler <IAnimal> animalHandler = new AnimalHandler<IAnimal>();
    
    animalEvaluator.Handle(dogs);
    animalEvaluator.Handle(cats);
