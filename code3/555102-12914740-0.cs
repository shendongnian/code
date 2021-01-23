    class Car<T> : ITestDrivable
    {
        public string color { get; set; }
        public virtual T features { get; set; }
        public virtual void TestDrive() { }
    }
