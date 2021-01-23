    public abstract class MainClass<A> where A:Animal
    {
        public A _animals;
    }
    
    public abstract class Animal
    {
        ...
    }
    
    public class Tiger : Animal
    {
        ...
    }
    
    public class Cat : Animal
    {
        ...
    }
    
    public class Leopard : Animal
    {
        ...
    }
    
    public class TypeA : MainSession<Cat>
    {
        ...
    }
    
    public class TypeB : MainSession<Leopard>
    {
        ....
    }
