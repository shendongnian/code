    public partial class login : UserControl
    {
        //Declare Event with CustomArgs
        public event EventHandler<TextChangedEventArgs> changeParentTextWithCustomEvent;
        private String customEventText = "Custom Events FTW!!!";
        public login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Check to see if the event is registered...
            //If not then do not fire event
            if (changeParentTextWithCustomEvent != null)
            {
                changeParentTextWithCustomEvent(sender, new TextChangedEventArgs(customEventText));
            }
        }
    }
