        public class A : ICloneable
        {
            public int PropertyA { get; private set; }
            public A()
            {
            }
            protected A(A copy)
            {
                this.PropertyA = copy.PropertyA;
            }
            public virtual object Clone()
            {
                return new A(this);
            }
        }
        public class B : A, ICloneable
        {
            public int PropertyB { get; private set; }
            public B()
            {
            }
            protected B(B copy)
                : base(copy)
            {
                this.PropertyB = this.PropertyB;
            }
            public override object Clone()
            {
                return new B(this);
            }
        }
