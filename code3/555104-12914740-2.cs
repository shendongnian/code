    class Car<T> : ITestDrivable
    {
        public string Color { get; set; }
        public virtual T Features { get; set; }
        public abstract void TestDrive() { }
    }
