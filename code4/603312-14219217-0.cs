    abstract class Animal
    {
        protected abstract Animal ProtectedGetMother();
        public Animal GetMother()
        {
          return this.ProtectedGetMother();
        }
    }
    class Cat : Animal
    {
        protected override Animal ProtectedGetMother()
        {
          do the work particular to cats here
          make sure you return a Cat
        }
        public new Cat GetMother()
        {
          return (Cat)this.ProtectedGetMother();
        }
     }
