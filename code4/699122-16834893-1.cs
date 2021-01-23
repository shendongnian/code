    public class BaseClass
    {
        private readonly _element;
        public BaseClass()
        {
            _element = default(UIElement);
        }
        public BaseClass(UIElement element)
        {
           _element = element;
        }
    }
