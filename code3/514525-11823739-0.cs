            protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Rectangle lasttabrect = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
            RectangleF emptyspacerect =
                new RectangleF(
                lasttabrect.X + lasttabrect.Width + tabControl1.Left,
                tabControl1.Top + lasttabrect.Y, 
                tabControl1.Width - (lasttabrect.X + lasttabrect.Width), 
                lasttabrect.Height);
            Brush b = Brushes.BlueViolet; // the color you want
            e.Graphics.FillRectangle(b, emptyspacerect );
        }
