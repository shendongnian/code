    @{
        Dictionary<string, object> AV = ViewData.ModelMetadata.AdditionalValues;
        Dictionary<string, object> htmlAttr = new Dictionary<string,object>();
        foreach (KeyValuePair<string, object> A in AV)
        {
            if (A.Value is System.Web.Routing.RouteValueDictionary)
            {
                foreach (KeyValuePair<string, object> B in (System.Web.Routing.RouteValueDictionary)A.Value)
                {
                    htmlAttr.Add(B.Key, B.Value);
                }
            }
        }
        htmlAttr.Add("class", "text-box single-line");
        htmlAttr.Add("type", "text");
    }
    @Html.TextBox("", ViewData.TemplateInfo.FormattedModelValue, htmlAttr)
