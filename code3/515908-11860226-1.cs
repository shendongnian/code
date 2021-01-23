    var responseString = new StringBuilder(sOutput);
    resposeString.AppendLine("|");
    foreach (DataRow drOutput in dtOutput.Rows)
    {
        foreach (DataColumn dcOutput in dtOutput.Columns)
        {
            resposeString.AppendFormat("{0}:", Convert.ToString(drOutput[dcOutput]));
        }
    }
    // Remove last : delimiter
    responseString.Remove(responseString.Length - 1, 1);
    
    resposeString.AppendLine("|");
    resposeString.Append(sClosedFault);
    resposeString.AppendLine("|");
    resposeString.Append(sTemp);
    Response.Write(responseString.ToString());
