    namespace WindowsFormsApplication1
        /// <summary>
        /// sample event args, can be used to carry additional information
        /// </summary>
        public class MyEventArgs : EventArgs
        {
            public string AdditionalInfo { get; set; }
        }
    public partial class UserControl1 : UserControl
    {
        
        /// <summary>
        /// event which will be raised
        /// </summary>
        public EventHandler<MyEventArgs> OnButtonClicked;
        public UserControl1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// normal button click, the event will be raised from here 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // check something has registered interest in the event (i.e. Form1)
            EventHandler<MyEventArgs> handler = OnButtonClicked;
            // if something is listening for this event, let let them know it has occurred
            if (handler != null)
            {
                handler(this, new MyEventArgs {AdditionalInfo = "some info"});
            }
        }
    }
