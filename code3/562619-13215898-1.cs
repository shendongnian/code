    StringBuilder stringBuilder = new StringBuilder();
    StringWriter writer = new StringWriter(stringBuilder);
    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
    try {
    	DV_TimeReportWraper.RenderControl(htmlWriter);
    } catch (HttpException generatedExceptionName) {
    }
    
    string DV_TimeReportWraper_innerHTML = stringBuilder.ToString();
