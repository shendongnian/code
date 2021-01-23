    protected void Page_Load(object sender, EventArgs e)
    {
        BindRepeater();
    }
    private void BindRepeater()
    {
        List<int> items = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            items.Add(i);
        }
        Repeater.DataSource = items;
        Repeater.DataBind();
    }
    protected void DeleteOnClick(object sender, EventArgs e)
    {
        ImageButton delbutton = (sender as ImageButton);
        //1- call your method with passing in delbutton.CommandArgument - it will give you key/ whatever you like
        //2- Rebind the Repeater here and that will bind controls again...
        BindRepeater();
    }
    protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ImageButton delbutton = (sender as RepeaterItem).FindControl("delbutton") as ImageButton;
        if (delbutton != null)
        {
            delbutton.CommandArgument = (sender as RepeaterItem).ItemIndex.ToString();
        }
    }
