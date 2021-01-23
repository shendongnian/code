    public class MessageWrapper
    {
        private BlockingCollection<int?> messageA = new BlockingCollection<int?>();
        private BlockingCollection<int?> messageB = new BlockingCollection<int?>();
        public Message WrapA(int a, int millisecondsTimeout)
        {
            messageA.Add(a);
            return CreateMessage(0);
        }
        public Message WrapB(int b, int millisecondsTimeout)
        {
            messageB.Add(b);
            return CreateMessage(millisecondsTimeout);
        }
        private Message CreateMessage(int timeout)
        {
            int? a, b;
            if (messageB.TryTake(out b) | messageA.TryTake(out a, timeout))
            {
                return new Message(a, b);
            }
            else
            {
                return null;
            }
        }
    }
