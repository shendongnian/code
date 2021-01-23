    protected void Button1_Click(object sender, EventArgs e)
        {
    
            Names = new NameDB();//Instantiation
            Names.Add("dss");//Object Reference is null
    
            GridView1.DataSource = Names.GetName();
            GridView1.DataBind();
        }
