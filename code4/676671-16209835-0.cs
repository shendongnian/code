        public interface IAnimal
        {
            public void Walk();
        }
    
        class Dog : IAnimal
        {
            public void Walk()
            {
                Console.WriteLine("Animal can walk");
            }
        }
