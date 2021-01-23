    class DataFilter
    {
        List<Animal> animals=null;
        public function1()
        {
            foreach (var animal in animals)
            {
                animal.function1();
            }
        }
    }
    abstract class Animal
    {
        public abstract void function1();
    }
    class Cat:Animal
    {
        public void function1()
        {}
    }
    class Dog:Animal
    {
        public void function1()
        {}
    }
