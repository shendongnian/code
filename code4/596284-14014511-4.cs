        public class myContextMenuStrip : ContextMenuStrip
        {
            public TreeNode tn;
            public myContextMenuStrip() { }
            protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
            {
                base.OnItemClicked(e);
                if (e.ClickedItem.Text == "asd") MessageBox.Show(tn.Text);
            }
        }
