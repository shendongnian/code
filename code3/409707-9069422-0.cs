    StringBuilder sb = new StringBuilder();
    sb.AppendLine("<SelectedValues>");
    foreach (string s in userSelectedValues)
      sb.AppendFormat("<row val=\"{0}\" />{1}", s, Environment.NewLine);
    sb.AppendLine("</SelectedValues>");
     
