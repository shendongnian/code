    public class TraceIDMutator : IMutateIncomingMessages, IMutateOutgoingMessages
    {
        public object MutateIncoming(object message)
        {
            var baseMsg = message as MessageBase;
            if (baseMsg != null)
                ThreadContext.Properties[Constants.TraceID] = baseMsg.TraceID;
            return message;
        }
        public object MutateOutgoing(object message)
        {
            var baseMsg = message as MessageBase;
            if(baseMsg != null)
            {
                if(baseMsg.TraceID == 0)
                {
                     var tid = ThreadContext.Properties[Constants.TraceID];
                     if (tid != null)
                         baseMsg.TraceID = (ulong)tid;
                }
            }
            return message;
        }
    }
