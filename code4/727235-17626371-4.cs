    public class Dog : Animal
    {
        public int DogYears { get; set; }  // This doesn't exist in the base class
    
        public Dog()
        {
            this.DogYears = 4;
        }
    }
