    public partial class ucTest : UserControl  
    {
       public event  EventHandler SomeEvent;
    
       private void OnSomeEvent()
       {
            EventHandler handler = SomeEvent;
            if(handler != null)
                 handler(this, EventArgs.Empty);
       } 
    
    }
  
    
    public partial class frmTest: Form
    {
        public frmTest()
        {
            ucTest uc = new ucTest(); 
            uc.SomeEvent += OuterEventInstance;
        }
        //...
        void OuterEventInstance(object sender, EventArgs e)
        {
            MessageBox.Show("Inner Call")
            //...
        }
    }
