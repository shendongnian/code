    public partial class Form1 : Form
    {
        public delegate void  trackbarscroll( object sender, EventArgs e);
        trackbarscroll tbs; 
        public Form1()
        {
            InitializeComponent();
            trackBar1.Scroll += new EventHandler(trackBar_Scroll);
            trackBar2.Scroll += new EventHandler(trackBar_Scroll);
            tbs = trackBar_Scroll; 
        }
        void trackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TrackBar)
                {
                    TrackBar tb = ctrl as TrackBar;
                    Invoke(tbs,tb, new EventArgs());
                }
            }
        }
    }
