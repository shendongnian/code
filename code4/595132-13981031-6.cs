    public class MyDecorator<T>
    {
        public MyDecorator(T decoratedObject)
        {
            this.DecoratedObject = decoratedObject;
        }
        public T DecoratedObject { get; private set; }
        public int MyDecoratorProperty1 { get; set; }
        public int MyDecoratorProperty2 { get; set; }
    }
