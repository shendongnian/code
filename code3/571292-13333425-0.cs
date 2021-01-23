    string content =
    @"<member name=""P:..."">
      <summary>This is the summary.</summary>
      <returns>This is the return info.</returns>
      </member>";
    XDocument doc = XDocument.Parse(content);                        
    foreach (var member in doc.Descendants("member"))
    {
         StringBuilder sb = new StringBuilder();
                
         sb.AppendLine("/// <summary>");
         sb.AppendLine("/// " + member.Descendants("summary").Select(e => e.Value).FirstOrDefault());
         sb.AppendLine("/// </summary>");
         sb.AppendLine("/// <returns>");
         sb.AppendLine("/// " + member.Descendants("returns").Select(e => e.Value).FirstOrDefault());
         sb.AppendLine("/// </returns>");
     }
