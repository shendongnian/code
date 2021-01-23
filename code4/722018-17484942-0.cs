    protected override void Render(HtmlTextWriter writer)
     {
         StringBuilder sb = new StringBuilder();
         StringWriter sw = new StringWriter(sb);
         HtmlTextWriter htw = new HtmlTextWriter(sw);
         base.Render(htw);
         string s = sb.ToString();
         //here you are able to use HTMLAgilityPack to parse HTML
         
         writer.Write(s);
     }
