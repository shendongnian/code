    String
       strConnection = "...",
       strSQL = "select * from Test",
    XElement objOutput = null;
    DataSet objDataSet = new DataSet("output");
    using (SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, strConnection)){
        objAdapter.Fill(objDataSet, "row");}
    using (StringWriter objWriter = new StringWriter()) { 
      objDataSet.WriteXml(objWriter);
      XDocument objDoc = XDocument.Parse(objDataSet.GetXml());
      objOutput = objDoc.Root;
    };
    return objOutput;
