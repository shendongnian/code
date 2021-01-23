    public Enum LabelAction{ None = 0, Clickable = 1, Resizable = 2, Draggable = 4 }
    
    public class Label
    {
        private readonly LabelAction _action;
        public class Label(LabelAction action){ this._action = action; }
        public bool CanClick 
        { 
            get
            {
                return this._action & LabelAction.Clickable == LabelAction.Clickable;
            }
        }
        public bool CanResize { get { return this._action & LabelAction.Resizable == LabelAction.Resizable ;} }
        public bool CanDrag { get { return this._action & LabelAction.Draggable == LabelAction.Draggable ;} }
        public Click()
        {
           if(this.CanClick) { /* click */ }
           else { throw new Exception("Not clickable");}
        }
        public Drag()
        {
           if(this.CanDrag) { /* drag */ }
           else { throw new Exception("Not draggable");}
        }
        public Resize()
        {
           if(this.CanResize) { /* resize */}
           else { throw new Exception("Not resizable");}
        }
    }
    var clickable = new Label(LabelAction.Clickable);
    var clickableDraggable = new Label(LabelAction.Clickable | LabelAction.Draggable);
