    abstract class CarFeatures { }
    
    class ToyotaFeatures : CarFeatures { }
    
    abstract class Car
    {
        public string color { get; set; }
        public virtual void TestDrive() { }
    }
    
    abstract class Car<T> : Car where T : CarFeatures
    {
        public virtual T features { get; set; }
    
        public Car(T _features)
        {
            features = _features;
        }
    }
    
    class Toyota : Car<ToyotaFeatures>
    {
        public override ToyotaFeatures features { get; set; }
        public Toyota(ToyotaFeatures _features) : base(_features) { }
        public override void TestDrive()
        {
            //Logic here...
        }
    }
