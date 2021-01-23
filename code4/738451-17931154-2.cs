        public void Shift(ScrollViewer target, double speed = 11, double distance = 20)
        {
            double startOffset = target.HorizontalOffset;
            double destinationOffset = target.HorizontalOffset + distance;
            if (destinationOffset < 0)
            {
                destinationOffset = 0;
                distance = target.HorizontalOffset;
            }
            if (destinationOffset > target.ScrollableWidth)
            {
                destinationOffset = target.ScrollableWidth;
                distance = target.ScrollableWidth - target.HorizontalOffset;
            }
            double animationTime = distance / speed;
            DateTime startTime = DateTime.Now;
            EventHandler renderHandler = null;
            renderHandler = (sender, args) =>
            {
                double elapsed = (DateTime.Now - startTime).TotalSeconds;
                if (elapsed >= animationTime)
                {
                    target.ScrollToHorizontalOffset(destinationOffset);
                    CompositionTarget.Rendering -= renderHandler;
                }
                target.ScrollToHorizontalOffset(startOffset + (elapsed * speed));
            };
            CompositionTarget.Rendering += renderHandler;
        }
