    public abstract class BaseFSM<TState, TTrigger> : IStateMachine 
    {
        #region Implementation of IStateMachine 
        public ICall LocalCall { get; set; } 
        #endregion 
     
        protected IList<TState> States { get; set; }
        protected IList<TTrigger> Triggers { get; set; }
     
        protected StateMachine<TState, TTrigger> fsm { get; set; } 
     
        public abstract void Fire(TTrigger trigger); 
    } 
    
    class Incoming_Initial : BaseFSM<Incoming_Initial.State, Incoming_Initial.Trigger>
    { 
        public enum State 
        { 
            WaitForCallToBeAnswered, 
            CallConnected, 
            CallNeverConnected, 
            CheckForCustomIntro, 
            PlayIntro, 
            PlayPleaseEnterPin, 
            ReadLanguageSettings, 
            ChooseLanguage, 
            ValidatePIN, 
            PINWasInvalid, 
            IdentifyUser 
        } 
     
        public enum Trigger 
        { 
            Yes, 
            No, 
            DigitPressed, 
            PromptDonePlaying, 
            PromptTimerElapse, 
            Done 
        } 
     
        public Incoming_Initial(ICall call) 
        { 
            States = (State[])Enum.GetValues(typeof(State));
            Triggers = (Trigger[])Enum.GetValues(typeof(Trigger));
            LocalCall = call; 
            fsm = new StateMachine<State, Trigger>(State.WaitForCallToBeAnswered); 
            .... 
