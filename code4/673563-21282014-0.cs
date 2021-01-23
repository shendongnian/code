     public abstract class MyBase
    {
        /// <summary>
        /// The my test method. divyang
        /// </summary>
        public virtual void MyVirtualMethodWhichIsOverridedInChild()
        {
            Console.Write("Method1 Call from MyBase");
        }
        /// <summary>
        /// The my another test method.
        /// </summary>
        public abstract void MyAnotherTestMethod();
        /// <summary>
        /// The my best method.
        /// </summary>
        public virtual void MyVirualMethodButNotOverridedInChild()
        {
            Console.Write("Method2 Call from MyBase");
        }
    }
