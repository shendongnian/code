    SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        private void myTreeView_drawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.IsSelected)
            {
                if (treeView1.Focused)
                    e.Graphics.FillRectangle(greenBrush, e.Bounds);
                else
                    e.Graphics.FillRectangle(redBrush, e.Bounds);
            }
            else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            e.Graphics.DrawRectangle(SystemPens.Control, e.Bounds);
            TextRenderer.DrawText(e.Graphics,
                                   e.Node.Text,
                                   e.Node.TreeView.Font,
                                   e.Node.Bounds,
                                   e.Node.ForeColor);
        }
