    class A
        {
            // Alternative
            static public virtual string TypeName { get { return "A"; } }
            public virtual string GetTypeName() { return "A"; }
        }
        class B : A
        {
            // Alternative
            public static override string TypeName { get { return "B"; } }
            public override string GetTypeName() { return "B"; }
        }
        class C : A
        {
            // Alternative
            public static override string TypeName { get { return "C"; } }
            public override string GetTypeName() { return "C"; }
        }
        class Executer
        {
            
            void ExecuteCommand(A val)
            {
                switch (val.GetTypeName())
                {
                    case "A": DoSomethingA((A)val);
                    case "B": DoSomethingB((B)val);
                    case "C": DoSomethingC((C)val);
                }
            }
            private void DoSomethingC(C c)
            {
                throw new NotImplementedException();
            }
            private void DoSomethingB(B b)
            {
                throw new NotImplementedException();
            }
            private void DoSomethingA(A a)
            {
                throw new NotImplementedException();
            }
        }
