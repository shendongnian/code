    abstract class Car
    {
        public string color { get; set; }
        public virtual void TestDrive() { }
    }
    
    abstract class Car<T> : Car
    {
        public virtual T features { get; set; }
    }
    
    class Toyota : Car<ToyotaFeatures>
    {
        public override ToyotaFeatures features { get; set; }
        public override void TestDrive()
        {
            //Logic here...
        }
    }
