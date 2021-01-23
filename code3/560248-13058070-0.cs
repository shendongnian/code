    enum AttachDirection { Right, Left, None }
    [ProvideProperty("IsRequired", typeof(Control))]
    class MyControl : UserControl, IExtenderProvider
    { 
        MyControl Left { get; set; } 
        MyControl Right { get; set; }
        public bool CanExtend(object extendee)
        {
            if (extendee is MyControl)
                return true;
            return false;
        }
        public void SetAttachTo (Control ctrl, AttachDirection direction)
        {
             if(direction == AttachDirection.Right)
                 this.setRight(ctrl);
             else if (direction == AttachDirection.Left)
                 this.setLeft(ctrl);
        }
        //And so on ...
    } 
