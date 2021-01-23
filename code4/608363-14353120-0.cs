    // Define the base class
    class Car
    {
        public virtual void DescribeCar()
        {
            System.Console.WriteLine("Four wheels and an engine.");
        }
    }
    
    // Define the derived classes
    class ConvertibleCar : Car
    {
        public new virtual void DescribeCar()
        {
            base.DescribeCar();
            System.Console.WriteLine("A roof that opens up.");
        }
    }
    
    class Minivan : Car
    {
        public override void DescribeCar()
        {
            base.DescribeCar();
            System.Console.WriteLine("Carries seven people.");
        }
    }
