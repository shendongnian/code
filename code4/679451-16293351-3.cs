    public string GetGridviewData(GridView gv)
    {
    StringBuilder strBuilder = new StringBuilder();
    StringWriter strWriter = new StringWriter(strBuilder);
    HtmlTextWriter htw = new HtmlTextWriter(strWriter);
    gv.RenderControl(htw);
    return strBuilder.ToString();
    }
