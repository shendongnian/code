        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.txtDesignTextBox1.Text = "From PreInit";
            this.txtDesignTextBox1.Text += DateTime.Now.ToString();
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            this.txtDesignTextBox2.Text = "From Init";
            this.txtDesignTextBox2.Text += DateTime.Now.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtDesignTextBox3.Text = "From Load";
            this.txtDesignTextBox3.Text += DateTime.Now.ToString();
        }
