    var responseString = new StringBuilder(sOutput);
    resposeString.AppendLine("|");
    
    var first = true;
    foreach (DataRow drOutput in dtOutput.Rows)
    {
        foreach (DataColumn dcOutput in dtOutput.Columns)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                resposeString.Append(":");
            }
            resposeString.AppendLine(Convert.ToString(drOutput[dcOutput]));
        }
    }
    
    resposeString.AppendLine("|");
    resposeString.Append(sClosedFault);
    resposeString.AppendLine("|");
    resposeString.Append(sTemp);
    Response.Write(responseString.ToString());
