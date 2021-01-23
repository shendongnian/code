    class Compass : VisualHost
    {
        private readonly List<ICompassPart> _children = new List<ICompassPart>();
        public void AddVisualChild(ICompassPart currentObject)
        {
            _children.Add(currentObject);
            AddVisualChild((Visual)currentObject);
        }
        override protected int VisualChildrenCount { get { return _children.Count; } }
        override protected Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count) throw new ArgumentOutOfRangeException();
            return _children[index] as Visual;
        }
        override protected void OnRender(DrawingContext dc)
        {
            //The control automatically renders its children based on their RenderContext.
            //There's really nothing to do here.
            dc.DrawRectangle(Background, null, new Rect(RenderSize));
        }
    }
    class Bezel : DrawingVisual
    {
       private bool _visible;
       public bool Visible {
       {
         get { return _visible; }
         set
         {
            _visible = value;
            Update();
         }
       }
       private void Update()
       {
           var dc = this.RenderOpen().DrawingContext;
           dc.DrawLine(/*blah*/);
           dc.Close();
       }
    }
