    public partial class Form1 : Form
    {
        private Timer tbTimer = new Timer();
        string myStr = "This is a test string to stylize your RichTextBox1";
        private int charPos = 0;
        public Form1()
        {
            InitializeComponent();
            tbTimer.Interval = 100;
            tbTimer.Tick += TbTimerOnTick;
 
        }
        private void TbTimerOnTick(object sender, EventArgs eventArgs)
        {
            if (charPos < myStr.Length - 1)
            {
                richTextBox1.AppendText(myStr[charPos++].ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                tbTimer.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tbTimer.Enabled = true;
        }
    }
