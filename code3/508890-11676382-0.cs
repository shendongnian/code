    using System;
    using System.Collections.Generic;
     
    namespace Polymorphism
    {
        class Program
        {
     
            public class Car
            {
                public string Drive()
                {
                    return "Wrrrr!";
                }
            }
     
            public class Dog 
            {
                public string Talk()
                {
                    return "Woof";
                }
            }
     
            static void Main()
            {
                var car = new Car();
                var dog = new Dog();
     
    	List<object> list = new List<object>();
    	list.Add(car);
    	list.Add(dog);
    
    	foreach (object o in list)
    	{
    		if (o is Car) 
    			Console.WriteLine((o as Car).Drive());
    		else
    			Console.WriteLine((o as Dog).Talk());
    	}
    
            }
        }
    }
