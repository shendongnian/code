    public static class ClickEvents // Prevent instantiation
    {
        public class SingleLeft { }
        public class SingleRight { }
    }
    eventAggregator.GetEvent<ClickEvents.SingleLeft>.Publish();
