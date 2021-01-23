    public class Consumer1
    {
        public void ConsumeClassX()
        {
            // Some hokey, arbitrary inputs:
            int MyInput = 200;
            int MyMultiplier = 2;
            // Consume Library Class Y using ConcreteClassYImplementationOne:
            AbstractLibraryClassY InstanceOf = new ConcreteClassYImplementationOne();
            InstanceOf.Multiplier = MyMultiplier;
            // Will output 400, per implementation defined in ConcreteClassYImplementationOne:
            Console.WriteLine("Output = " + InstanceOf.MethodA(MyInput).ToString());
            // Consume Library Class Y using ConcreteClassYImplementationTwo:
            InstanceOf = new ConcreteClassYImplementationTwo();
            InstanceOf.Multiplier = MyMultiplier;
            // Will output 405, per implementation defined in ConcreteClassYImplementationTwo:
            Console.WriteLine("Output = " + InstanceOf.MethodA(MyInput).ToString());
        }
    }
