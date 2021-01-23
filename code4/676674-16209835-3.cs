        public interface IAnimal
        {
            public void Walk(); // Just declares the method, not implemenation
        }
    
        //Class implementing the interface 
        //must define the method specified in the interface
        class Dog : IAnimal
        {
            public void Walk()
            {
                Console.WriteLine("Dog can walk");
            }
        }
