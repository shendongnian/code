    string rtf;
    
    public void ProcessRequest(HttpContext context)
    {
       if (context.Request.Form.Count > 0)
       {
          rtf = context.Request.Form[0];
          string html = "";
          if (rtf != "")
          {
    		 Thread thread = new Thread(ConvertMarkup);
    			thread.SetApartmentState(ApartmentState.STA);
    			thread.Start();
    			thread.Join();
          }
          if (html != "")
          {
             context.Response.ContentType = "text/html";
             context.Response.Write(html);
          }
          else
          {
             context.Response.ContentType = "text/plain";
             context.Response.Write("Error from RTF2HTML");
          }
       }
    }
    
    void ConvertMarkup()
    {
    	markupConverter = new MarkupConverter.MarkupConverter();
    	 html = markupConverter.ConvertRtfToHtml(rtf);
    }
