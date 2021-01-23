    public class MailProvider : IProvider
    {
        private readonly IHandler handler;
        private readonly IPreProcessor preProcessor;
        public MailProvider(IHandler handler, 
            IPreProcessor preProcessor)
        {
            this.handler = handler;
            this.preProcessor = preProcessor;
        }
        public void SomeAction() { ... }
    }
