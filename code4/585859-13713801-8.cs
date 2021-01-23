    public partial class MessagePage : PhoneApplicationPage
    {
        private readonly Pin pin;
    
        public MessagePage(Pin _pin)
        {        
            this.pin = _pin;
        }
                    
        public Pin Pin
        {
            get
            {
                return pin;
            }
        }
