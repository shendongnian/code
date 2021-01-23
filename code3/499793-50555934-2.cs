    private void PrintPage_Print(object sender, PrintPageEventArgs e)
        {
            using (Font f = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point))
            {
                using (Brush b = new SolidBrush(Color.Black))
                {
                    using (Graphics g = e.Graphics)
                    {
                        float y = 5;
                        string headLine = "Article\tUnit\tNet\tGross";
                        Pen pen = new Pen(b);
                        SizeF measure = g.MeasureString(headLine, f);                        
                        StringFormat format = new StringFormat();
                        
                        float[] tabs = new float[] { 200, 100, 55, 55};
                        Rectangle rect = new Rectangle(5, (int)y, (int)(tabs.Sum()+5), (int)measure.Height);
                        format.SetTabStops(0, tabs);
                        
                        g.DrawString(headLine, f, b, rect, format);
                        g.DrawRectangle(pen, rect);
                        y += rect.Height + 3f;
                        format.LineAlignment = StringAlignment.Far;
                        foreach (var product in Bill.ListPositions())
                        {
                            measure = g.MeasureString(product.PositionString, f);
                            rect = new Rectangle(5, (int)y, (int)(tabs.Sum()+5), (int)measure.Height);
                            g.DrawString(product.PositionString, f, b, rect, format);
                            y += measure.Height + 2f;
                        }
                        g.DrawLine(pen, new Point(0, (int)y), new Point((int)(tabs.Sum()), (int)y));
                        tabs = new float[] { 300, 110 };
                        format.LineAlignment = StringAlignment.Near;
                        format.SetTabStops(0, tabs);
                        foreach (var line in DrawTotalSummaryLines())
                        {
                            measure = g.MeasureString(line, f);
                            rect = new Rectangle(5, (int)y, (int)(tabs.Sum()+5), (int)measure.Height);                            
                            g.DrawString(line, f, b, rect, format);
                            y += measure.Height + 2f;
                            if (line.Contains("Gross:") ||line.Contains("CHANGE:"))
                            {
                                g.DrawLine(pen, new Point(0, (int)y), new Point((int)(tabs.Sum()), (int)y));
                                y += measure.Height + 2f;
                            }
                        }
                        g.Dispose();
                        pen.Dispose();
                    }
                    b.Dispose();
                }
                f.Dispose();
            }
