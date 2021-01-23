    public class MyClass
    {
        public bool DomeSomethingSpecific(int i)
        {
                var child1 = new Child1("a","b");
                ((myBaseClass)child1).DomeSomethingSpecificForChild1(i);
        }
    }
