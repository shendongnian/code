    sqlQuery = "select name, data,data2 from surgicalfiledemo where id = @id";
    SqlCommand cmd = new SqlCommand(sqlQuery, con);
    cmd.Parameters.AddWithValue("@id", surgicalGridView.SelectedRow.Cells[1].Text);
    //SqlDataReader dr = cmd.ExecuteReader(); use sqldata adapter to load all the data then fill to to Datatable and Bind it on GridView
    SqlDataAdapter adapt = new SqlDataAdapter();
    DataTable dt = new DataTable();
    adapt.SelectCommand = cmd;
    adapt.Fill(dt);
    GridView GridView1 = new  GridView();
    GridView1.DataSource = dt;
    GridView1.DataBind();
    // if (dr.Read()) {  .. }  this causes you to return single record only, your export to excel execute every time a row was read thats why you can only see one record.
    Response.Clear();
    Response.Buffer = true;
    string filename="MyExportedData.xls"; 
    Response.AddHeader("content-disposition","attachment;filename="+filename);
    Response.Charset = "";
    Response.ContentType = "application/vnd.ms-excel";
    StringWriter sw = new StringWriter();
    HtmlTextWriter hw = new HtmlTextWriter(sw);
    GridView1.RenderControl(hw);
    Response.Output.Write(sw.ToString());
    Response.Flush();
    Response.End();
