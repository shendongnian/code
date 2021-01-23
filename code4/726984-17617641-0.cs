    public class ZipResult : ActionResult
    {
        private IEnumerable<string> _files;
        private string _fileName;
     
        public string FileName
        {
            get
            {
                return _fileName ?? "file.zip";
            }
            set { _fileName = value; }
        }
     
        public ZipResult(params string[] files)
        {
            this._files = files;
        }
     
        public ZipResult(IEnumerable<string> files)
        {
            this._files = files;
        }
     
        public override void ExecuteResult(ControllerContext context)
        {
            using (ZipFile zf = new ZipFile())
            {
                zf.AddFiles(_files, false, "");
                context.HttpContext
                    .Response.ContentType = "application/zip";
                context.HttpContext
                    .Response.AppendHeader("content-disposition", "attachment; filename=" + FileName);
                zf.Save(context.HttpContext.Response.OutputStream);
            }
        }
     
    } 
