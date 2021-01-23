       public override void ExecuteResult(ControllerContext context)
        {
           // this.FileName = context.RouteData.GetRequiredString("action");
            var fileContent =  Convert(wkhtmltopdfPath, switches, null, wkhtmlExe);
            var response = this.PrepareResponse(context.HttpContext.Response);
            response.OutputStream.Write(fileContent, 0, fileContent.Length);
        }
        protected HttpResponseBase PrepareResponse(HttpResponseBase response)
        {
            response.ContentType = this.GetContentType();
            this.FileName = "YourFile.pdf";
            if (!String.IsNullOrEmpty(this.FileName))
            response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", SanitizeFileName(this.FileName)));
            response.AddHeader("Content-Type", this.GetContentType());
            return response;
        }
 
 
