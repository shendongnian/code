    public class A
    {
        public A(int someNumber)
        {
        }
    }
    // This will not compile becase A doesn't have a default constructor and B 
    // doesn't inherit A's constructors.
    public class B : A
    {
    }
