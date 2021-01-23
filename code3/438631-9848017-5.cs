    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
            
            this.ControlAdded += Control_Added;
            //  subscribe to the event and provide the implementation
            Number.OnWelcomAccepted += (o, e) => { Controls.Add(GetControl( )); }
        }
        private void Control_Added(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            //  process size and placement and show
        }
    
    }
