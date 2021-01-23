    interface IMyType
    {
        object InnerType { get; set; }
        void PerformMethod1();
    }
    
    class Namespace1MyTypeWithInterface : Namespace1.MyType, IMyType
    {}
