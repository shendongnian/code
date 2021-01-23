    public class Apple : Fruit
    { 
        ...
        Shape shape = this + giraffe; // Legal!
    }
    public class Giraffe : Animal
    {
        ...
        Shape shape = apple + this; // Illegal!
    }
