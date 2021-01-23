    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
            
            //  subscribe to the event and provide the implementation
            Number.OnWelcomAccepted += (o, e) => { Form1.Controls.Add(GetControl( )); }
        }
    
    }
