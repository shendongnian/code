    ...
    private void reflectionTryOut()
            {
                string validate = typeof(C).GetFamilyTree();
            }
        }
    
        public class A
        {}
    
        public class B : A
        {}
    
        public class C : B
        {}
