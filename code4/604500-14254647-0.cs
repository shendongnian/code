    for (int i = 0; i < myData.Count(); i++)
    {
        sb.AppendLine(string.Join(delimiter, 
                                  " = \"",
                                  Common.FormatExportString(myData[i].Code),
                                  Common.FormatExportString(myData[i].Name),
                                  Common.FormatExportString(myData[i].Description)
                                  "\""));
    }
    //returns the file after writing the stream to the csv file.
    return File(new System.Text.UTF8Encoding().GetBytes(sb.ToString()), "text/csv", fileName);
