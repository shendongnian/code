	Response.Clear();
	Response.Buffer = true;
	//use Response.AddHeader
	Response.AddHeader("content-disposition", "attachment;filename=Test.xls");
	Response.Charset = "";
	Response.ContentType = "application/vnd.xls ";
	StringWriter sw = new StringWriter();
	HtmlTextWriter hw = new HtmlTextWriter(sw);
	GridView1.RenderControl(hw);
	GridView1.AllowPaging = false;
	GridView1.DataBind(); // bind data 
	Response.Output.Write(sw.ToString());
	//need to call Flush and End methods 
	Response.Flush();
	Response.End();
