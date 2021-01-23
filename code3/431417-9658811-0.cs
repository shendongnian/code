    // Declare XmlTextReader.
    XmlTextReader r = new XmlTextReader("../../persons.xml");
    
    //Add this stringBuilder
    StringBuilder sb = new StringBuilder();
    while (r.Read())
    {
        switch (r.NodeType)
        {
            case XmlNodeType.Element:
                if (r.Name == "Persons")
                {
                    sb.Append("<table>");
                    sb.Append("    <tr> <th>Name</th> <th>Gender</th> <th>Age</th> </tr>");
                }
                else if (r.Name == "Person")
                {
                    sb.Append("    <tr> ");
                }
                else if (r.Name == "Name" ||
                         r.Name == "Gender" || r.Name == "Age")
                {
                    sb.Append("<td>");
                }
                break;
           case XmlNodeType.Text:
                sb.Append(r.Value);
                break;
           case XmlNodeType.EndElement:
                if (r.Name == "Persons")
                {
                    sb.Append("</table>\n");
                }
                else if (r.Name == "Person")
                {
                    sb.Append("</tr>\n");
                }
                else if (r.Name == "Name" ||
                         r.Name == "Gender" || r.Name == "Age")
                {
                    sb.Append(">/td> ");
                }
                break;
        }
    }
    //Add the result value to a literal control on the aspx page
    Literal1.Text=sb.ToString();
