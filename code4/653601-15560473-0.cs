        public interface IAnimal
        {
            [Obsolete("Animals can't eat anymore", true)]
            void Eat();
        }
    
        public class Animal : IAnimal
        {
            [Obsolete("Animals can't eat anymore", true)]
            public void Eat()
            {
                Console.WriteLine("Hello");
            }
        }
