        using System.Threading; 
        Thread t = new Thread(new ThreadStart(ProcessRequest)); 
        // Make sure to set the apartment state BEFORE starting the thread. 
        t.ApartmentState = ApartmentState.STA; 
        t.Start(); 
        public void ProcessRequest(HttpContext context)
        {
           if (context.Request.Form.Count > 0)
           {
            string rtf = context.Request.Form[0];
            string html = "";
            if (rtf != "")
            {
               markupConverter = new MarkupConverter.MarkupConverter();
               html = markupConverter.ConvertRtfToHtml(rtf);
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
