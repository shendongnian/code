    public  string GenerateXML(List<District> Districts)
     var xml = new StringBuilder();
     var insertxml = new StringBuilder();
     xml.Append("<Stores>");
     for (var i = 0; i < Districts.Count; i++)
            { var obj = Districts[i];
              insertxml.Append("<Store");
              insertxml.Append(" Name=\"" + obj.Name  + "\" ");
              insertxml.Append(" Image=\"" + obj.Image + "\" ");
              insertxml.Append(" />");
            }
    xml.Append("<InsertList>");
    xml.Append(insertxml.ToString());
   
    SqlCommand cmd= new SqlCommand("insertStore",connectionString);
    cmd.CommandType=CommandType.StoredProcedure;
    SqlParameter param = new SqlParameter ();
    param.ParameterName ="@XMLData";
    param.value=xml;
    paramter.Add(param);
    cmd.ExecuteNonQuery();
 
