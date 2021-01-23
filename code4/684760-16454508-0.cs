    // create you generic controls
    HtmlGenericControl mainDiv = new HtmlGenericControl("div");
    // setting required attributes and properties
    // adding more generic controls to it
    // finally, get the html when its ready
    StringBuilder generatedHtml = new StringBuilder();
    HtmlTextWriter htw = new HtmlTextWriter(new StringWriter(generatedHtml));
    mainDiv.RenderControl(htw);
    string output = generatedHtml.ToString();
