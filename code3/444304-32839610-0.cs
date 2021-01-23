                protected override void Render(HtmlTextWriter writer)
                {
                    var sw = new System.IO.StringWriter();
                    var tw = new HtmlTextWriter(sw);
                    base.Render(tw);
                    var html = sw.ToString();            
                    html = html.Replace("\n", " ");
                    html = html.Replace("\r", " ");
                    html = html.Replace("\t", " ");
                    var data = html.Replace("\"", "\\\"");
                    data = data.Replace("/", "\\/");
                    var json = String.Format("{{\"html\":\"{0}\"}}", data);
                    Response.ContentType = "application/json";
                    Response.Write(json);
                    Response.Flush();
                    Response.End();
                }
