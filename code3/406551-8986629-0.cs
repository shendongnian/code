            g.DrawImage(res, p);            
            //left
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, p.X, dest_size.Height));
            //right
            g.FillRectangle(Brushes.Black, new Rectangle(p.X + act_size.Width, 0, p.X, dest_size.Height));
            //up
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, dest_size.Width, p.Y));
            //down
            g.FillRectangle(Brushes.Black, new Rectangle(0, p.Y + act_size.Width, dest_size.Width, p.Y));
