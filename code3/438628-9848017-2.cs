    public partial class Number : UserControl
    {
        //  event handler Form1 will subscribe to
        public EventHandler<EventArgs> OnWelcomeAccepted = (o, e) => { };
    
        public Number()
        {
            InitializeComponent();
        }
    
        private void btnAcceptWelcome_Click(object sender, EventArgs e)
        {
              //  raise the event
              OnWelcomeAccepted(sender, e);
        }
    }
