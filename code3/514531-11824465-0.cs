    public class mytab : TabControl
    {
        public mytab()
            : base()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
        }
        private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.SelectedIndex)
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshFore = Brushes.Black;
                //bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.LightSkyBlue , Color.LightGreen, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                //bshFore = Brushes.Blue;
            }
            else
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.Red);
                bshFore = new SolidBrush(Color.Aqua);
                //bshBack = new SolidBrush(Color.White);
                //bshFore = new SolidBrush(Color.Black);
            }
            string tabName = this.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
            Rectangle r = this.GetTabRect(this.TabPages.Count - 1);
            RectangleF tf =
                new RectangleF(r.X + r.Width,
                r.Y-5, this.Width - (r.X + r.Width)+5, r.Height+5);
            Brush b = Brushes.BlueViolet;
            e.Graphics.FillRectangle(b, tf);
        }
     
    }
