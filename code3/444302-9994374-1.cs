        protected override void Render(HtmlTextWriter writer)
        {
            var sw = new System.IO.StringWriter();
            var tw = new HtmlTextWriter(sw);
            base.Render(tw);
            Response.Write(String.Format("{{\"myresponse\": {{  \"id": \"123",\"html\":\"{0}\"}}}}"
            , Server.HtmlEncode(sw.ToString()).Replace("\n"," "));
            Response.Flush();
            Response.End();
        }
