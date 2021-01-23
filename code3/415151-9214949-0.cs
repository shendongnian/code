	if(Session["testPanel"] == null)
	{
		TextWriter stringWriter = new StringWriter();
		HtmlTextWriter renderOnMe = new HtmlTextWriter(stringWriter);
        // render and get the actually html of this dom tree
		testPanel.RenderControl(renderOnMe);
        // save it as cache
		Session["testPanel"] = stringWriter.ToString();		
	}
	// render the result on a literal 
	cLiteralID.Text = Session["testPanel"];
    // hide the panel because I have render it on literal.
	testPanel.Visible = false;
