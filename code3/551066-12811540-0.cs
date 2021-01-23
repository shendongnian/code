    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
      System.IO.StringWriter stringWriter = 
          new System.IO.StringWriter();
      HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
      base.Render(htmlWriter);
      string html = stringWriter.ToString();
      string[] aspnet_formelems = new string[5];
      aspnet_formelems[0] = "__EVENTTARGET";
      aspnet_formelems[1] = "__EVENTARGUMENT";
      aspnet_formelems[2] = "__VIEWSTATE";
      aspnet_formelems[3] = "__EVENTVALIDATION";
      aspnet_formelems[4] = "__VIEWSTATEENCRYPTED";
      foreach (string elem in aspnet_formelems)
      {
        //Response.Write("input type=""hidden"" name=""" & abc.ToString & """")
        int StartPoint = html.IndexOf("<input type=\"hidden\" name=\"" + 
          elem.ToString() + "\"");
        if (StartPoint >= 0)
        {
          //does __VIEWSTATE exist?
          int EndPoint = html.IndexOf("/>", StartPoint) + 2;
          string ViewStateInput = html.Substring(StartPoint, 
            EndPoint - StartPoint);
          html = html.Remove(StartPoint, EndPoint - StartPoint);
          int FormStart = html.IndexOf("<form");
          int EndForm = html.IndexOf(">", FormStart) + 1;
          if (EndForm >= 0)
            html = html.Insert(EndForm, ViewStateInput);
        }
      }
    
      writer.Write(html);
    }
 
