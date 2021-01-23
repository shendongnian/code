    public class Animal { }
    public class Dog : Animal { }
    public void HandleAnimal<T>() where T : Animal
    {
    
    }
    public void HandleDog<T>() where T : Dog
    {
    
    }
