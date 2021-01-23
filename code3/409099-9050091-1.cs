       private abstract class InheritanceTest
        {
            public virtual object Property
            {
                get { return null; }
                protected set { }
            }
            public class Child : InheritanceTest
            {
                public override object Property
                {
                    get { return null; }
                    protected set { base.Property = null; }
                }
            }
        }
