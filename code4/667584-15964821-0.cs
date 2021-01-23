    protected void ConvertToExcel_Click(object sender, System.EventArgs e)
    {
	Response.ContentType = "application/vnd.ms-excel";
	Response.AddHeader("content-disposition",     "attachment;filename=ContactMailingAddress.xls");
	Response.Charset = "";
	StringWriter sw = new StringWriter();
	HtmlTextWriter hw = new HtmlTextWriter(sw);
	ContactMailingView.AllowPaging = false;
	ContactMailingView.DataBind();
	        
	
        //Apply style to Individual Cells
	
        ContactMailingView.HeaderRow.Cells(0).Style.Add("background-color", "yellow");
	ContactMailingView.HeaderRow.Cells(1).Style.Add("background-color", "yellow");
	ContactMailingView.HeaderRow.Cells(2).Style.Add("background-color", "yellow");
	ContactMailingView.HeaderRow.Cells(3).Style.Add("background-color", "yellow");
	ContactMailingView.HeaderRow.Cells(4).Style.Add("background-color", "yellow");
	
	for (int i = 0; i <= ContactMailingView.Rows.Count - 1; i++) {
		GridViewRow row = ContactMailingView.Rows(i);
		
                //Change Color back to white
		row.BackColor = System.Drawing.Color.White;
		
                //Apply text style to each Row
		row.Attributes.Add("class", "textmode");
		
                //Apply style to Individual Cells of Alternating Row
		if (i % 2 != 0) {
			row.Cells(0).Style.Add("background-color", "#C2D69B");
			row.Cells(1).Style.Add("background-color", "#C2D69B");
			row.Cells(2).Style.Add("background-color", "#C2D69B");
			row.Cells(3).Style.Add("background-color", "#C2D69B");
			row.Cells(4).Style.Add("background-color", "#C2D69B");
			
		}
	}
	
         ContactMailingView.RenderControl(hw);
	
        //style to format numbers to string
	string style = "<style>.textmode{mso-number-format:\\@;}</style>";
	Response.Write(style);
	Response.Output.Write(sw.ToString());
	Response.Flush();
	Response.End();
