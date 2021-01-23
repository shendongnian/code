    interface IAnimal {}
    class Dog : IAnimal { public void Bark () ; }
    class Cat : IAnimal { public void Meow () ; }
    var dogs = new FileImpl<Dog, Dog> () ;
    dogs.t1  = new Dog () ;
    
    var file = (IFile<IAnimal, IAnimal>) dogs ; // if this were OK...
    file.t1  = new Cat () ;                     // this would have to work
    dogs.t1.Bark () ;                           // oops, t1 is a cat now
