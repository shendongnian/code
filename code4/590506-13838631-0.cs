    public class BaseClass
    {
        public  IChildClass ChildClassInstance = new ChildClass();
    }
    public class ChildClass : IChildClass
    {
        public void myMethod(int i)
        { /* do something with i */ }
        public void myMethod(int a, string b)
        { /* get i from a and b and call: */ myMethod(i); }
        public void myMethod(string c, string d)
        { /* get i from c and d and call: */ myMethod(i); }
    }
    public interface IChildClass
    {
        void myMethod(int i);
        void myMethod(int a, string b);
    }
