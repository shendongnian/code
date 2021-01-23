    public class Dog
    {
        private int numberOfTeeth;
        public int NumberOfTeeth {get {return numberOfTeeth;}}
        public Dog() 
        { 
            countTeeth(); 
        }
        private void countTeeth()
        {
            this.numberOfTeeth = 5; //this dog has seen better days, apparently
        }
    }
