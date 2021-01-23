       abstract class Animal 
       {
           abstract public void Voice(); //
       }
    
       class Dog : Animal
       {
           public void Voice() 
           {
               Console.WriteLine("bark!");
           }
       }
    
       class Cat: Animal
       {
           public void Voice() 
           {
               Console.WriteLine("meow!");
           }
       }
