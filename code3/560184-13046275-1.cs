    internal static void ContentToBrowser(string contentType, string filename, string content)
            // Send to browser
            var response = HttpContext.Current.Response;
            response.Clear();
            response.ContentType = contentType;
            response.AddHeader("Content-Disposition", 
                        String.Format("attachment; filename=\"{0}\"", filename));
            var contentLength = response.ContentEncoding.GetByteCount(content);
            response.AddHeader("Content-Length", contentLength.ToString());
            response.Write(content);
            response.End();
    }
