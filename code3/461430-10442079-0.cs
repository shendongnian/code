     private List<string> addContent(string content)
    {
        //create a generic list of string type
        List<string> s = new List<string>();
        for (int i = 0; i < 10; i++)
        {
            s.Add(content);
        }
        return s;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
       //Passed the List<> as DataSource and then bind the content in the list<> in the  DataGrid
        this.DataGrid1.DataSource = this.addContent(this.txtadd.Text);
        this.DataGrid1.DataBind();
    }
