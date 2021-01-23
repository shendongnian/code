    public delegate void UpdateTextCallback(double ask, double bid);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string symbol = "GBPUSD";
            MT4DDE dde = new MT4DDE("");
            dde.OnQuote += new EventHandler<QuoteEventArgs>(MT_OnQuote);
            dde.Connect();
            dde.Subscribe(symbol);
        }
        private void updateTickDisplay(double ask, double bid)
        {
            textBox1.Text = ask.ToString();
            textBox2.Text = bid.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MT_OnQuote(object sender, QuoteEventArgs args)
        {
            BeginInvoke(new UpdateTextCallback(this.updateTickDisplay),
            new object[] { args.Ask, args.Bid });
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox1.Text;
        }
    }
