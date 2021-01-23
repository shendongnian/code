    public class Dog : Animal
    {
        public Dog(Animal a) 
        {
            base.set(a);
        }
    
        public void sniffBum()
        {
            Console.WriteLine("sniff sniff sniff");
        }
    }
.
    i could just create a new Dog object, and pass the values accross, (...), but this just seems messy
