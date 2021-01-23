    // create you generic controls
    HtmlGenericControl mainDiv = new HtmlGenericControl("div");
    // setting required attributes and properties
    // adding more generic controls to it
    // finally, get the html when its ready
    StringBuilder generatedHtml = new StringBuilder();
    using (var htmlStringWriter = new StringWriter(generatedHtml))
    {
        using(var htmlTextWriter = new HtmlTextWriter(htmlStringWriter))
        {
            mainDiv.RenderControl(htmlTextWriter);
            output = generatedHtml.ToString();       
        }
    }
