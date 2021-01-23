    using System;
    interface IValue { string Value { get; } }
    interface IParent : IValue { IChild Child { get; } }
    interface IChild : IValue { IParent Parent { get; } }
    abstract class HasValue : IValue
    {
        private string value;
        public HasValue(string value)
        {
            this.value = value;
        }
        public string Value { get { return value; } }
    }
    sealed class GreenChild : HasValue
    {
        public GreenChild(string value) : base(value) {}
    }
    sealed class GreenParent : HasValue
    {
        private GreenChild child;
        public GreenChild Child { get { return child; } }
        public GreenParent(string value, GreenChild child) : base(value)
        { 
             this.child = child; 
        }
        public IParent MakeFacade() { return new RedParent(this); }
        private sealed class RedParent : IParent
        {
            private GreenParent greenParent;
            private RedChild redChild;
            public RedParent(GreenParent parent) 
            { 
                this.greenParent = parent; 
                this.redChild = new RedChild(this);
            }
            public IChild Child { get { return redChild; } }
            public string Value { get { return greenParent.Value; } }
            private sealed class RedChild : IChild
            {
                private RedParent redParent;
                public RedChild(RedParent redParent)
                {
                    this.redParent = redParent;
                }
                public IParent Parent { get { return redParent; } }
                public string Value 
                { 
                    get 
                    { 
                        return redParent.greenParent.Child.Value; 
                    } 
                }
            }
        }
    }
    class P
    {
        public static void Main()
        {
            var greenChild1 = new GreenChild("child1");
            var greenParent1 = new GreenParent("parent1", greenChild1);
            var greenParent2 = new GreenParent("parent2", greenChild1);
            var redParent1 = greenParent1.MakeFacade();
            var redParent2 = greenParent2.MakeFacade();
            Console.WriteLine(redParent1.Value); // parent1
            Console.WriteLine(redParent1.Child.Parent.Value); // parent1 !
            Console.WriteLine(redParent2.Value); // parent2
            Console.WriteLine(redParent2.Child.Parent.Value); // parent2 !
            // See how that goes? RedParent1 and RedParent2 disagree on what the
            // parent of greenChild1 is, **but they are self-consistent**. They
            // always report that the parent of their child is themselves.
        }
    }
