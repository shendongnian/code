    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0 && e.Index < data.Count)
            {
                e.DrawFocusRectangle();
                Bitmap bmp = new Bitmap(e.Bounds.Width, e.Bounds.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(listView1.BackColor);
                string url = data[e.Index].Substring(0, 4);
                Font f = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
                SizeF size = e.Graphics.MeasureString(url, f);
                RectangleF urlRectF = new RectangleF(e.Bounds.X, 0, size.Width, e.Bounds.Height);
                g.DrawString(url, f, new SolidBrush(Color.Red), urlRectF); 
                RectangleF restRectF = new RectangleF(e.Bounds.X + size.Width, 0, e.Bounds.Width - size.Width, e.Bounds.Height);
                g.DrawString(data[e.Index].Substring(4), f, new SolidBrush(Color.Green), restRectF);
                e.Graphics.DrawImage(bmp,e.Bounds);
                g.Dispose();
            }
        }
