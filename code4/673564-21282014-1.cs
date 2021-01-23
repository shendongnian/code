    public class CrtpChild : CrtpBaseWrapper<CrtpChild>
    {
        /// <summary>
        /// The my test method. divyang
        /// </summary>
        public override void MyVirtualMethodWhichIsOverridedInChild()
        {
            Console.Write("Method1 Call from CrtpChild");
        }
        /// <summary>
        /// The my another test method.
        /// </summary>
        public override void MyAnotherTestMethod()
        {
            Console.Write("MyAnotherTestMethod Call from CrtpChild");
        }
    }
