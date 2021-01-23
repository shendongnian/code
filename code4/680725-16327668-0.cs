    public void MergeXmls(string xml1, string xml2)
    {
        string mergedXml = "<root>" + xml1 + xml2 + "</root>;
        xmlDisplay.DocumentContent = mergedXml;
        xmlDisplay.TransformSource = Server.MapPath("transform.xslt");
    }
