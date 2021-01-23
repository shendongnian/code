    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
         //access data here
         //assign value here
         phone.Text = phoneNum.ToString();  
      }
    }   
