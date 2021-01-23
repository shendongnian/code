    public partial class DrawingForm : Form
    {
        Timer m_oTimer = new Timer ();
        public DrawingForm ()
        {
            InitializeComponent ();
            m_oTimer.Tick += new EventHandler ( m_oTimer_Tick );
            m_oTimer.Interval = 2000;
            m_oTimer.Enabled = false;
        }
        // Enable the timer and call m_oTimer.Start () when
        // you're ready to draw your lines.
        void m_oTimer_Tick ( object sender, EventArgs e )
        {
            // Draw the next line here; disable
            // the timer when done with drawing.
        }
    }
