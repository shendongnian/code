    protected void ExportToExcel(object sender, EventArgs e)
    {
        //Get the data from database into datatable
        string strQuery = "select CustomerID, ContactName, City, PostalCode" +" from customers";
        SqlCommand cmd = new SqlCommand(strQuery);
        DataTable dt = GetData(cmd);
        //Create a dummy GridView
        GridView GridView1 = new GridView();
        GridView1.AllowPaging = false;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition","attachment;filename=DataTable.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            //Apply text style to each Row
            GridView1.Rows[i].Attributes.Add("class", "textmode");
        }
        GridView1.RenderControl(hw);
        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
