    int count = 1;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lbl.Text = count.ToString();
        }
    }
    
    protected void btn_Click(object sender, EventArgs e)
    {
        if (int.TryParse(lbl.Text, out count))
        {                
            lbl.Text = (++count).ToString();
        }
    }
