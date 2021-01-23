    private List<string> gvValues;
    
    protected override void OnInit(EventArgs e)
    {
        gvValues = new List<string>();
        GridView1.DataSource = gvValues;
        GridView1.DataBind();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
         gvValues.Add(TextBox1.Text);
         GridView1.DataSource = gvValues;
         GridView1.DataBind();
    }
