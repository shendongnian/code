    public partial class TimerCTR : Form
    {
        public TimerCTR()
        {
            InitializeComponent();
        }
    
        private void TimerCTR_Load( object sender, EventArgs e )
        {
            TimerInstance.Start();
        }
    
        private void TimerInstance_Tick( object sender, EventArgs e )
        {
            Thread.Sleep( 5000 );
        }
    
        private void button1_Click( object sender, EventArgs e )
        {
            MessageBox.Show( "Hello" );
        }
    }
