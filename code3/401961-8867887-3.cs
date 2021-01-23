     public partial class DerivedClassB : BaseClass, IInterface
        {
            public void BarFoo()
            {
                this.Bar();
                this.Foo();
            }
        }
