    public class RoundButton : Button
    {
        GraphicsPath borderPath;
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }
        private void UpdateRegion()
        {
            borderPath = new GraphicsPath();
            borderPath.AddArc(new Rectangle(0, 0, Height, Height), 90, 180);
            borderPath.AddLine(new Point(Height / 2, 0), new Point(Width - Height / 2, 0));
            borderPath.AddArc(new Rectangle(Width - Height, 0, Height, Height), -90, 180);
            borderPath.AddLine(new Point(Width - Height / 2, Height), new Point(Height / 2, Height));
            Region = new Region(borderPath);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.Clear(Color.Black);            
            Color cl1 = isMouseOver ? Color.FromArgb(100, Color.Yellow) : Color.FromArgb(100, Color.Aqua);
            Color cl2 = isMouseOver ? Color.Yellow : Color.Aqua;
            if (MouseButtons == MouseButtons.Left) cl2 = cl1;
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, cl1, cl2, 90))
            {
                pevent.Graphics.FillPath(brush, borderPath);
                pevent.Graphics.ScaleTransform(0.8f, 0.4f);                
                pevent.Graphics.TranslateTransform(0.1f * ClientSize.Width, 0.1f * ClientSize.Height, MatrixOrder.Append);
            }
            if(!(MouseButtons == MouseButtons.Left)) 
                pevent.Graphics.FillPath(new SolidBrush(Color.FromArgb(100, Color.White)), borderPath);
            pevent.Graphics.ResetTransform();
            pevent.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            float penSize = MouseButtons == MouseButtons.Left ? 4 : 2.5f;
            using (Pen pen = new Pen(Color.Gray) { Width = penSize })
            {
                pevent.Graphics.DrawPath(pen, borderPath);
            }
            using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center })
            {
                Rectangle rect = ClientRectangle;
                if (MouseButtons == MouseButtons.Left) rect.Offset(-1, -1);
                pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rect, sf);
            }
        }
        bool isMouseOver;        
        protected override void OnMouseEnter(EventArgs e)
        {
             base.OnMouseEnter(e);
             isMouseOver = true;             
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isMouseOver = false;            
        }        
    }
