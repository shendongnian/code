    [TestFixture]
    public class NewTest
    {
        [Test]
        public void WhatGetsPrinted()
        {
            A a= new B();
            a.Print();  //This uses B's Print method since it overrides A's
            // a.ProtectedProperty is not accesible here
        }
    }
    public class A
    {
        protected string ProtectedProperty { get; set; }
        private string PrivateProperty { get; set; }
        public virtual void Print()
        {
            Console.WriteLine("A");
        }
    }
    public class B : A
    {
        public override void  Print() // Since Print is marked virtual in the base class we can override it hhere
        {
            //base.PrivateProperty can not be accessed hhere since it is private
            base.ProtectedProperty = "ProtectedProperty can be accessed here since it is protected and B:A";
            Console.WriteLine("B");
        }
    }
