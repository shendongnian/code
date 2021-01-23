    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Lable1.Text = string.IsNullOrEmpty(Lable1.Text) ? "0" :
            (Convert.ToInt32(Lable1.Text) + 1).ToString();  
    }
