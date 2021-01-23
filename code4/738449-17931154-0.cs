        public void Shift(ScrollViewer target, double speed = 11, double distance = 20)
        {
            double animationTime = distance / speed;
            double startOffset = target.HorizontalOffset;
            double destinationOffset = target.HorizontalOffset + distance;
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
