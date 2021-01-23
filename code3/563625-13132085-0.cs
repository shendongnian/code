    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.IsBalloon = true;
            toolTip1.Popup += new PopupEventHandler(toolTip1_Popup);
            toolTip1.SetToolTip(textBox1, "");
        }
        void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (toolTip1.GetToolTip(e.AssociatedControl) == "")
                e.Cancel = true;
            
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            toolTip1.RemoveAll();
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            int temp;
            if (!int.TryParse(textBox1.Text, out temp))
                showTip("Validation Error", (Control)sender);
        }
        private void showTip(string message, Control destination)
        {
            toolTip1.Show(message, destination);
            timer1.Start();
        }
    }
