        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
            string txt = e.Node.Text;
            int idx = txt.IndexOf(' ');
            string greenTxt;
            string redTxt;
            if (idx >= 0)
            {
                greenTxt = txt.Substring(0, idx);
                redTxt = txt.Substring(idx);
            }
            else
            {
                greenTxt = txt;
                redTxt = string.Empty;
            }
            Rectangle greenRect = new Rectangle(e.Bounds.Location, new Size((int)Math.Ceiling(e.Graphics.MeasureString(greenTxt, nodeFont).Width), e.Bounds.Height));
            Rectangle redRect = new Rectangle(e.Bounds.Location + new Size(greenRect.Width, 0), new Size((int)Math.Ceiling(e.Graphics.MeasureString(redTxt, nodeFont).Width), e.Bounds.Height));
            e.Graphics.DrawString(greenTxt, nodeFont, Brushes.Green, greenRect);
            if (!string.IsNullOrEmpty(redTxt))
                e.Graphics.DrawString(redTxt, nodeFont,
                    Brushes.Red, redRect);
        }
