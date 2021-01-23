    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.PreRender += new EventHandler(GridView1_PreRender);
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
       if (GridView1.Rows.Count > 0)
       {
         //forces grid to render thead/th elements 
         GridView1.UseAccessibleHeader = true; 
         GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
       }
    }
