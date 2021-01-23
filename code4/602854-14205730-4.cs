        Control Parse(XElement element)
        {
            var root = new XElementControlPair(element, ControlWrapper.Create(element));
            
            var stack = new Stack<XElementControlPair>();
            stack.Push(root);
            while (stack.Any()) //here we recursively search for any child elements
            {
                var elem = stack.Pop();
                var children = from child in elem.XElement.Elements() 
                               let ctl = ControlWrapper.Create(child)                               
                               where child.Attribute("type") != null 
                               select new XElementControlPair(child, ctl);
                foreach (var child in children)
                {
                    stack.Push(child);
                    elem.Control.Controls.Add(child.Control);
                }
                
            }
            return root.Control.MakeControl();
        }
    class XElementControlPair
    {
        public XElement XElement { get; private set; }
        public ControlWrapper Control { get; private set; }
        public XElementControlPair(XElement elem, ControlWrapper ctl)
        {
            this.XElement = elem;
            this.Control = ctl;
        }
    }
    abstract class ControlWrapper
    {
        public List<ControlWrapper> Controls { get; private set; }
        protected readonly XElement element;
        public ControlWrapper(XElement element)
        {
            this.element = element;
        }
        public static ControlWrapper Create(XElement element)
        {
            var type = element.Attribute("type").Value.ToLower();
            switch (type)
            {
                case "image":
                    return new ImageWrapper(element);
                
                case "textbox":
                    return new TextBoxWrapper(element);
                case "checkbox":
                    return new CheckBoxWrapper(element);
                //etc...
            }
        }
        protected abstract Control _MakeControl(); //here is where you tell it how to construct a particular control given an XElement
        public Control MakeControl()
        {
            var ctl = _MakeControl();
            foreach (var child in Controls)
                ctl.Children.Add(child.MakeControl());
            return ctl;
        }
        
    }
