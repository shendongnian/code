        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {            
            base.OnResultExecuted(filterContext);
            var r = filterContext.Result as FilePathResult; // not FileContent           
            string fileName =
               filterContext.RequestContext.HttpContext.Server.MapPath(r.FileName);   
            filterContext.HttpContext.Response.Flush();
            filterContext.HttpContext.Response.End();
         
            System.IO.File.Delete(fileName);
        }
