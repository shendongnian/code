    public class MyTreeView : TreeView
    {
        public bool TextBoxChanged { get; set; }
        public MyTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(customTreeView_DrawNode);
        }
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            //comment  the below line to create your own Invalidate
            //base.OnInvalidated(e);
        }
        private void customTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (!TextBoxChanged)
            {              // Draw the whole control(tree and info)
                drawNode(e);
                drawInfo(e);
            }
            else
            {                              // Draw only info
                drawInfo(e);
            }
        }
        private void drawNode(DrawTreeNodeEventArgs e)
        {
            //...........
        }
        private void drawInfo(DrawTreeNodeEventArgs e)
        {
            //...........
        }
    }
