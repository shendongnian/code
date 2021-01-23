    //First, as I said, you have to set treeView.CheckBoxes = true;
    //Second, set treeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
    //Add this DrawNode event handler and enjoy =)
    private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)//If the Node is a Parent
            {                
                int d = (int)(0.2*e.Bounds.Height);
                Rectangle rect = new Rectangle(d + treeView.Margin.Left, d, e.Bounds.Height - d*2, e.Bounds.Height - d*2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                e.Graphics.DrawRectangle(Pens.Silver, rect);
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", treeView.Font, new SolidBrush(Color.Blue), rect, sf);                
                //Draw text
                sf.Alignment = StringAlignment.Near;
                Rectangle textRect = new Rectangle(e.Bounds.Left + rect.Right + 4, e.Bounds.Top, e.Bounds.Width - rect.Right - 4, e.Bounds.Height);
                if (e.Node.IsSelected)
                {
                    SizeF textSize = e.Graphics.MeasureString(e.Node.Text, treeView.Font);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                }
                e.Graphics.DrawString(e.Node.Text, treeView.Font, new SolidBrush(treeView.ForeColor), textRect,sf);
            }
            else e.DrawDefault = true;
        }
