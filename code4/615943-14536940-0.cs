    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string myStr = "This is a test string to stylize your RichTextBox1";
            ThreadPool.QueueUserWorkItem(ShowTextInInterval, myStr);
        }
        private void ShowTextInInterval(object state)
        {
            string mystr = state as string;
            if (mystr == null)
            {
                return;
            }
            for (int i = 0; i < mystr.Length; i++)
            {
                AppendNewTextToRichTextBox(mystr[i]);
                Thread.Sleep(100);
            }
        }
        private delegate void app_char(char c);
        private void AppendNewTextToRichTextBox(char c)
        {
            if (InvokeRequired)
            {
                Invoke(new app_char(AppendNewTextToRichTextBox), c);
            }
            else
            {
                richTextBox1.AppendText(c.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
