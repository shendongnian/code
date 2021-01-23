    public class BaseClass
    {
        private _element;
        public BaseClass()
        {
            _element = default(UIElement);
        }
        public BaseClass(UIElement element)
        {
           _element = element;
        }
        public UIElement Element
        {
          get{ return _element; }
          set{ _element = value; }
        }
    }
