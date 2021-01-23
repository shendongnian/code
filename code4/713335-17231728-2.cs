    class Animal {}
    class Cat : Animal {}
    
    class Prog {
        public delegate Animal AnimalHandler();
        public static Animal GetAnimal(){...}
        public static Cat GetCat(){...}
        AnimalHandler animalHandler = GetAnimal;
        AnimalHandler catHandler = GetCat;        //covariance
    }
