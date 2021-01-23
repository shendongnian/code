                try 
            {
                using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (System.IO.Stream responseStream = httpResponse.GetResponseStream())
                    {
                        //var filepath = @"C:\Users\David\Downloads\UberwriterUSRReport.pdf";
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.ContentType = "application/pdf";
                        HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("atachment; filename=UberwriterUSRReport.pdf"));
                        HttpContext.Current.Response.BufferOutput = true;
                        CopyStream(responseStream, HttpContext.Current.Response.OutputStream);
                    }
                }
            }
