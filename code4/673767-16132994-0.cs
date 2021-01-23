            Rect position1 = new Rect();
            position1.Location = ellips1.PointToScreen(new Point(0, 0));                
            position1.Height = ellips1.ActualHeight;
            position1.Width = ellips1.ActualWidth;
            Rect position2 = new Rect();
            position2.Location = ellips2.PointToScreen(new Point(0, 0));
            position2.Height = ellips2.ActualHeight;
            position2.Width = ellips2.ActualWidth;
            if (position1.IntersectsWith(position2))
            {
                ...
            }
