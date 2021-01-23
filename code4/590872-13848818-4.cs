    public static class ClickEvents // Prevent instantiation
    {
        public class SingleLeft { }
        public class SingleRight { }
        public class DoubleLeft { }
        public class DoubleRight { }
        // Are there any more click events possible?!
    }
    eventAggregator.GetEvent<ClickEvents.SingleLeft>.Publish();
