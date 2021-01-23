        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostback)
           {
             this.xx.Visible = CheckBox1.Checked;
           }
        }
