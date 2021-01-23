    public class WizardHost : IHandle<MoveNext>
    {
        private readonly IEventAggregator messageBus
        public WizardHost(IEventAggregator messageBus)
        {
            this.messageBus = messageBus;
            this.messageBus.Subscribe(this);
        }
        /here you might have the 'real' command method, e.g:
        public void GoToNextQuestion()
        {
            // do stuff
        }
        public void Handle(MoveNext message)
        {
            GoToNextQuestion();
        }
    }
    public class WizardPage 
    {
        private readonly IEventAggregator messageBus;
        private bool shouldMoveToNext;
        public WizardPage(IEventAggregator messageBus)
        {
            this.messageBus = messageBus;
        }
        public void DoStuff()
        {
            //at some point, you might want to switch the flag or do whatever you need/want to do and:
            if(shouldMoveToNext)
                messageBus.Publish(new MoveNext());
        }
    }
