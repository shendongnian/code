    private void listBox_DrawItem(object sender, DrawItemEventArgs e)
            {
                if (e.Index == -1)
                {
                    return;
                }
    
                e.DrawBackground();
                Graphics g = e.Graphics;
    
                var selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                var lb = (ListBox)sender;
    
                if (selected)
                {
                    g.FillRectangle(new SolidBrush(Color.DarkBlue), e.Bounds);
                    g.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.White), new PointF(e.Bounds.X, e.Bounds.Y));
                    return;
                }
    
                var item = (ProjectToDoRecord)lb.Items[e.Index];
                var textColor = item.TrafficLight();
                g.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                g.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(textColor), new PointF(e.Bounds.X, e.Bounds.Y));
            }
