    class MyTreeView : TreeView
    {
        protected override void OnMouseUp(MouseEventArgs e)
        {
            MessageBox.Show("Are we getting here?");
            base.OnMouseUp(e);
        }
    
    }
