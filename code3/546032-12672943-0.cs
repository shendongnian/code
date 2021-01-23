    class Program
        {
            private static void Main(string[] args)
            {
                ConsumingDerivedClass x = new ConsumingDerivedClass();
                // Wrong DoWork is called - expected calling of DoWork(DerivedDataClass) but actually called DoWork(BaseDataClass) 
                x.DoWork(new DerivedDataClass());
                x.DoWork(new BaseDataClass());
                Console.ReadKey();
            }
        }
    
        public class ConsumingBaseClass
        {
            public virtual void DoWork(BaseDataClass instance)
            {
                Console.WriteLine("ConsumingBaseClass.DoWork(DerivedDataClass); Type of argument is '{0}'", instance.GetType());
            }
        }
    
        public class ConsumingDerivedClass : ConsumingBaseClass
        {
            public override void DoWork(BaseDataClass instance)
            {
                Console.WriteLine("ConsumingDerivedClass.DoWork(DerivedDataClass); Type of argument is '{0}'", instance.GetType());
                base.DoWork(instance);
                // Some additional logic 
            }
    
            public void DoWork(DerivedDataClass instance)
            {
                Console.WriteLine("ConsumingDerivedClass.DoWork(BaseDataClass); Type of argument is '{0}'", instance.GetType());
                DerivedDataClass derivedInstance = new DerivedDataClass();
                // Some logic based on what is in baseInstacne 
                derivedInstance.SomeProperty = "Value, got from some logic";
    
                base.DoWork(derivedInstance);
                // Some additional logic 
            }
        }
    
        public class BaseDataClass
        { }
    
        public class DerivedDataClass : BaseDataClass
        {
            public string SomeProperty { get; set; }
        } 
