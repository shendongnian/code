      class Rabbit : Animal
    {
        int bartVal; // using a local int should force a call to memory for each instance of the class
        public Rabbit():base(3)
        {
        bartVal = 3;
        }
        public override int Bart
        {
            get
            {
                return bartVal;
            }
        }
    }
