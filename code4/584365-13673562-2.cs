    public partial class Form1 : Form {
        public Form1( ) {
            InitializeComponent( );
            CheckForIllegalCrossThreadCalls = false;   // Note!!
        }
    
        public void SetText( string text ) {
            label1.Text = text;
        }
    }
