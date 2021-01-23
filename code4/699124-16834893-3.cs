    public class ClassA: BaseClass
    {
        public ClassA(UIElement element)
            : base(element)
        {
        }
    }
    
    public class ClassA: BaseClass
    {
        public ClassA(UIElement element)
        {
           Element = element;
        }
    }
