    public void ReirectPost(string redirectUrl, Dictionary<string,string> vars)
    {
      Response.Clear();
      StringBuilder sb = new StringBuilder();
      sb.Append("<html>");
      sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
      sb.AppendFormat("<form name='form' action='{0}' method='post'>", redirectUrl);
      foreach(var v in vars)
        sb.AppendFormat("<input type='hidden' name='{0}' value='{1}'>", v.Key, v.Value);
      sb.Append("</form></body></html>");
      Response.Write(sb.ToString());
      Response.End();
    }
