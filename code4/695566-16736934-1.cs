    class UIRect {
        ...
    }
    interface IUIContainer {
        IEnumerable<IUIElement> AllElements {get;}
        void AddElement(IUIElement toAdd);
    }
    class UIContainer : IUIContainer {
        public IEnumerable<IUIElement> AllElements {
            get {
                ...
            }
        }
        public void AddElement(IUIElement toAdd) {
            ...
        }
    }
    class Multiple : UIRect, IUIContainer {
        private readonly IUIContainer _cont = new UIContainer();
        ...
        public IEnumerable<IUIElement> AllElements {
            get {
                return _cont.AllElements;
            }
        }
        public void AddElement(IUIElement toAdd) {
            _cont.AddElement(toAdd);
        }
    }
