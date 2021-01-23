    public static class CancellableEventChain
    {
        public static EventHandler CreateFrom(params CancelEventHandler[] chain)
        {
            return (sender, dummy) =>
            {
                var args = new CancelEventArgs(false);
                foreach (var handler in chain)
                {
                    handler(sender, args);
                    if (args.Cancel)
                        break;
                }
            };
        }
    }
