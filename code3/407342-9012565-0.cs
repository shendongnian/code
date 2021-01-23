        public void Compare()
        {
            
            foreach (List<Label> labels in LabelsList)
            {
                Rect position1 = new Rect();
                position1.Location = labels[1].PointToScreen(new Point(0, 0));                
                position1.Height = labels[1].ActualHeight;
                position1.Width = labels[1].ActualWidth;
                Rect position2 = new Rect();
                position2.Location = labels[0].PointToScreen(new Point(0, 0));
                position2.Height = labels[0].ActualHeight;
                position2.Width = labels[0].ActualWidth;
                if (position1.IntersectsWith(position2))
                {
                    labels[1].Foreground = new SolidColorBrush(Colors.Green);
                    continue;
                }
                labels[1].Foreground = new SolidColorBrush(Colors.Red);
            }
        }
