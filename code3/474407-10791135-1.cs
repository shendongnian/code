        class A
        {
            // Alternative
            string typeName =  this.GetType().Name;
            public virtual string TypeName { get { return typeName; } }
            public virtual string GetTypeName() { return "A"; }
        }
        class B : A
        {
            public override string GetTypeName() { return "B"; }
        }
        class C : A
        {
            public override string GetTypeName() { return "C"; }
        }
        class Executer
        {
            
            void ExecuteCommand(A val)
            {
                Console.WriteLine(val.GetType().Name);
                switch (val.GetTypeName())
                {
                    case "A": DoSomethingA(val as A); break;
                    case "B": DoSomethingB(val as B); break;
                    case "C": DoSomethingC(val as C); break;
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
