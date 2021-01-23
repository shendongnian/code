    		string filename = "Test.xls"; 
    		System.IO.StringWriter tw = new System.IO.StringWriter();
    		System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
    		
    		//Get the H`enter code here`TML for the control.
    		yourGrid.RenderControl(hw);
    		//Write the HTML back to the browser.
    		Response.ContentType = "application/vnd.ms-excel";
    		Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
    
    		Response.Write(tw.ToString());
