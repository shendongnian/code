    protected void page_load(Object sender, EvenetArgs e)
    {
        if(!IsPostBack)
         {
              listBox1.DataSource = getAllListCourses(); // f.e. a DataTable
              listBox1.DataTextField  = "TextColumn";
              listBox1.DataValueField = "IdColumn";
              listBox1.DataBind();
         }
    }
