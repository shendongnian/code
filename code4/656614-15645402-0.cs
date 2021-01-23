    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)    
       {
            lblNum1.Text = random.Next(0, 10).ToString();
            lblNum3.Text = random.Next(0, 10).ToString();
            int num1 = int.Parse(lblNum1.Text);
            int num2 = int.Parse(lblNum3.Text);
            lblAnswer.Text = (num1 + num2).ToString();
            lblAnswer.Visible = false;
      }
    }
