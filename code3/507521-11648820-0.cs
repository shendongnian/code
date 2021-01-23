        public void PromptToSend(NetContext context)
        {
            if(Interlocked.CompareExchange(ref writerCount, 1, 0) == 0)
            { // then **we** are the writer
                context.Handler.StartSending(this);
            }
        }
