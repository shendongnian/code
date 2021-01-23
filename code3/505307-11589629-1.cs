     protected override void Render(System.Web.UI.HtmlTextWriter writer)         
     {
          // intercept the output stream and write to your own 
          // StringWriter, bound to a StringBuilder
          var sb = new StringBuilder();
          var sw = new StringWriter(sb);
          base.Render(sw);
          
          string html = sb.ToString();
 
          // do stuff to alter "html"
          ..
          // write it to the real output stream
          
          writer.Write(html)
     }
