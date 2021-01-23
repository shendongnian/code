    namespace Rextester
    {
        public class Program
        {
        public abstract class Animal {
        }
        public class Dog : Animal {
        }
        public class Cat : Animal {
        }
        public class AnimalHandler {
            public virtual void Pet<T>(T animal) {
                Console.WriteLine(typeof(T));
            }
        }
    
        public class Problem {
            public List<Animal> Animals { get; set; }
            private readonly AnimalHandler _animalHandler;
    
            public Problem(AnimalHandler animalHandler) {
                _animalHandler = animalHandler;
                Animals = new List<Animal> { new Cat(), new Dog() };
            }
    
            public void MakeDecision() {
                foreach (var animal in Animals) {
                     _animalHandler.Pet(animal);
                }
            }
        }
    
            public static void Main(string[] args)
            {
                List<Animal> animals = new List<Animal>();
                animals.Add(new Dog());
                animals.Add(new Cat());
                    
                var handler = new AnimalHandler();
                handler.Pet((dynamic)animals[0]);
                handler.Pet((dynamic)animals[1]);
            }
        }
    }
