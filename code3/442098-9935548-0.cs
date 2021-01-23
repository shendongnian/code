        protected void Page_Load(object sender, EventArgs e)
        {
          if (!Page.IsPostBack)
          {
            inputs.Items.Add("input1");
            inputs.Items.Add("input2");
            inputs.Items.Add("input3");
            inputs.Items.Add("input4");
          }
        }
