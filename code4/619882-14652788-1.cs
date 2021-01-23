    public void ConvertDataSetToExcel(DataSet dataSet, string strTempFileName)
    {
        XmlDocument xmlDataDoc = null;
        XslCompiledTransform xslTransform = new XslCompiledTransform();
        StreamReader srrReader = null;
        
        XmlTextReader xtrRdr = null;
        StringWriter stwWriter = null;
        StreamWriter srwWriter = null;
        xmlDataDoc = new XmlDocument();
        xmlDataDoc.LoadXml(dataSet.GetXml());
        srrReader = new StreamReader(path_to_embedded_xsl);
        xtrRdr = new XmlTextReader(srrReader);
        stwWriter = new StringWriter();
        xslTransform.Transform(xmlDataDoc, null, stwWriter);
        xslTransform.Transform(xmlDataDoc, null, stwWriter);
        srwWriter = new StreamWriter(strTempFileName);
        srwWriter.Write(stwWriter.ToString());
        srwWriter.Close();
    }
