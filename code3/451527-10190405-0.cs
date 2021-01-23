    public class NewRichTextBox : RichTextBox
    {
        public string[] TotalText;
        private bool filter = false;
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (!filter)
                TotalText = Text.Split('\n');
        }
        public void Filter(string sf)
        {
            filter = true;
            Text = "";
            foreach (string _s in TotalText)
            {
                if (_s.Contains(sf))
                    Text += _s + "\n";
            }
            filter = false;
        }
    }
        public Form1()
        {
            InitializeComponent();
            NewRichTextBox myrtb = new NewRichTextBox();
            myrtb.Name = "NRTB";
            Controls.Add(myrtb);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NewRichTextBox mtrb = (NewRichTextBox)Controls.Find("NRTB", false)[0];
            mtrb.Filter("Filter");
        }
