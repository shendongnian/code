        interface IDeepCloneable<T>
    {
        T DeepClone();
    }
    interface IObject<T> : IDeepCloneable<T>
    {
        string Name { get; }
        double Sales { get; }
    }
    //'BObject' does not implement interface member
    //  'IDeepCloneable<IObject>.DeepClone()'
    class BObject : IObject<BObject>
    {
        public string Name { get; set; }
        public double Sales { get; set; }
        public BObject DeepClone()
        {
            return new BObject() { Name = this.Name, Sales = this.Sales };
        }
    }
