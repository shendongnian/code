    public class TreeView1 : TreeView
    {
        protected override void OnMouseUp(MouseEventArgs e)
        {
            MessageBox.Show("Are we getting here?");
            base.OnMouseUp(e);
        }
    }
    
    ...
    //now when declaring it it'll be easier to tell the difference
    private TreeView1 treeView1;
