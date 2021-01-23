        public abstract class BaseClass
        {
            public object contents { get; set; }
            public Action<BaseClass> mutator;
            public abstract void Initialise();
        }
        public static class Mutators
        {
            public static void VariantA(BaseClass baseClass)
            {
                // inputObj.contents = something else
            }
            public static void VariantB(A inputObj) { } // etc. etc.
        }
        public class A : BaseClass
        {
            public A()
            {
                mutator = Mutators.VariantA;
            }
            public override void Initialise()
            {
                /* set the value of contents property here */
            }
        }
