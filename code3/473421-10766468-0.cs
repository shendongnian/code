    public partial class Main : FormMain
    {
        Data ClientData; //Contains all temporary data within the GUI
    
        public frmMain()
        {
             ClientData = new Data();
             DataListener dataListener = new DataListener();
             // Add an event handler
             dataListener.somethingReceivedHandler += 
                 (object sender, SomethingData packet)              
                 {
                    if (someContext) ClientData.SomeList.Add(packet); 
                 };
             InitializeComponent();
        }
