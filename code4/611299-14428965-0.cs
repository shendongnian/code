    public partial class TimeClock : UserControl
    {
        public DateTime LoginTime{ get; set; }
    
        public event UserControlActionHandler ActionEvent;
        public delegate void UserControlActionHandler (object sender, EventArgs e);
    
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    
        protected void Button_Click(object sender, EventArgs e)
        {
           if (this.ActionEvent!= null)
           {
               this.ActionEvent(sender, e);
           }
        }
     
    }
