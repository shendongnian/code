    class Program
    {
    
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            Wolf wolf = new Wolf();
    
            var babyJo = new Baby();
            babyJo.AddAnimalToScaryList(wolf);
            babyJo.IsAffraidOf(wolf);   //true
            babyJo.IsAffraidOf(cat);    //false
    
            var babySam = new Baby();
            babySam.AddAnimalToScaryList(wolf);
            babySam.AddAnimalToScaryList(cat);
            babySam.IsAffraidOf(wolf);   //true
            babySam.IsAffraidOf(cat);    //true
    
            var babyBob = new Baby();
            babyBob.IsAffraidOf(wolf);   //false
            babyBob.IsAffraidOf(cat);    //false
        }
    }
