    using (TextWriter stringWriter = new StringWriter())
    {
    	using (HtmlTextWriter RenderOnMe = new HtmlTextWriter(stringWriter))
    	{
    		// render the control
    		TreeHead.RenderControl(RenderOnMe);
                
            // transfor here the stringWriter as you like    
    		// now add it to the string
    		FinalTable = "<xml>" + stringWriter.ToString() + "</xml>";
    	}
    }
    
    // hide the control, and only render the FinalTable
    TreeHead.Visible = false;
