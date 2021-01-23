    public class Label
    {
        private readonly LabelAction _action;
        private string Text { get; set; }
        public class Label(string text)
            : Label(text, LabelAction.None) { } 
        public class Label(string text, LabelAction action)
        {
            this.Text = text;
            this._action = action; 
        }
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
