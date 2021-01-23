        protected void Page_Load(object sender, EventArgs e)
        {
            Process p = new Process(this);
            string s = p.GetTextBoxValue();
        }
