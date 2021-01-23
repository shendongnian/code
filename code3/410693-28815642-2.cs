    class Parent : UIElement
    {
        //...
        void Parent_AddChildControl()
        {
            ChildControl child = new ChildControl();
            child.MouseEnter += child_MouseEnter;
            UiElementX.Children.Add(child);
        }
        void child_MouseEnter( object sender , MouseEventArgs e )
        {
            ((ChildControl)sender).ChildControl_MouseEnter(sender, e);
        }
    }
    class ChildControl : UIElement
    {
        //...
    
        public void ChildControl_MouseEnter(object sender, MouseEventArgs e)
        {
            //event handling
        }
    }
