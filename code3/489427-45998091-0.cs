        public int TopVisibleItem { get; private set; }
        private double CurrentDistance;
        
        private void TouchScroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (myItemControl.Items.Count > 0)
            {
                MoveDirection direction = (MoveDirection)Math.Sign(e.VerticalChange);
                if (direction == MoveDirection.Positive)
                    while (CurrentDistance < e.VerticalOffset && TopVisibleItem < myItemControl.Items.Count)
                    {
                        CurrentDistance += ((FrameworkElement)myItemControl.Items[TopVisibleItem]).ActualHeight;
                        TopVisibleItem += 1;
                    }
                else
                    while (CurrentDistance >= e.VerticalOffset && TopVisibleItem > 0)
                    {
                        CurrentDistance -= ((FrameworkElement)myItemControl.Items[TopVisibleItem]).ActualHeight;
                        TopVisibleItem -= 1;
                    }
            }
        }
        public enum MoveDirection
        {
            Negative = -1,
            Positive = 1,
        }
