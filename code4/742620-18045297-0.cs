    public partial class marqueText : UserControl
    {
        private Color colFColor;
        private Color colBColor;
        private int timeDelay = 1;
        private string[] scrollText = new string[] { "" };
        private int scrollTextCount;
        private int scrollTextCurrentPosition;
        public marqueText()
        {
            InitializeComponent();
            scrollTextCurrentPosition = 0;
            scrollTextCount = MarqueText.Count();
        
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
          
                lblDisplay.Text = scrollText[scrollTextCurrentPosition];
                scrollTextCurrentPosition++;
                if (scrollTextCurrentPosition == scrollTextCount)
                {
                    scrollTextCurrentPosition = 0;
                }
            
        }
        public int MarqueTimeDelay
        {
            get
            {
                return timeDelay;
            }
            set
            {
                timeDelay = value;
                this.timer1.Interval = value * 1000;
            }
        }
        public string[] MarqueText
        {
            get
            {
                scrollTextCount = scrollText.Count();
                return scrollText;
            }
            set
            {
                scrollText = value;
                scrollTextCount = scrollText.Count();
            }
        }
        public Color MarqueBackColor
        {
            get
            {
                return colBColor;
            }
            set
            {
                colBColor = value;
                lblDisplay.BackColor = colBColor;
            }
        }
        public Color MarqueForeColor
        {
            get
            {
                return colFColor;
            }
            set
            {
                colFColor = value;
                lblDisplay.ForeColor = colFColor;
            }
        }
    }
