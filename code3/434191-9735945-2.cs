    protected override void Render (HtmlTextWriter writer)
    {
    	StringBuilder sb = new StringBuilder();
    	HtmlTextWriter tw = new HtmlTextWriter(new System.IO.StringWriter(sb));
    	//Render the page to the new HtmlTextWriter which actually writes to the stringbuilder
    	base.Render(tw);
    	
    	//Get the rendered content
    	string sContent = sb.ToString();
    	
    	//Now output it to the page, if you want
    	writer.Write(sContent);
    }
