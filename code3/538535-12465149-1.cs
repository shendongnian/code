      StringBuilder sb = new StringBuilder();
      sb.Append("<root>");
      sb.Append(FileUtil.ReadFileContent(fileName));  // Encoding ??
      sb.Append("</root>");
      return XDocument.Parse(sb.ToString()); 
