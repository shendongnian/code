    public class SynchronisedScrollToken
    {
        List<ScrollViewer> registeredScrolls = new List<ScrollViewer>();
        internal void unregister(ScrollViewer scroll)
        {
            throw new NotImplementedException();
        }
        internal void register(ScrollViewer scroll)
        {
            scroll.ScrollChanged += ScrollChanged;
            registeredScrolls.Add(scroll);
        }
        private void ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var sendingScroll = sender as ScrollViewer;
            foreach (var potentialScroll in registeredScrolls)
            {
                if (potentialScroll == sendingScroll)
                    continue;
                if (potentialScroll.VerticalOffset != sendingScroll.VerticalOffset)
                    potentialScroll.ScrollToVerticalOffset(sendingScroll.VerticalOffset);
                if (potentialScroll.HorizontalOffset != sendingScroll.HorizontalOffset)
                    potentialScroll.ScrollToHorizontalOffset(sendingScroll.HorizontalOffset);
            }
        }
    }
