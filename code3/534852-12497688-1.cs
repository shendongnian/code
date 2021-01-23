        public string FILEPATH = "";
        public string StorageRoot(HttpContext context)
        {
            if (context.Session["fuFilePath"] != null)
                FILEPATH = context.Session["fuFilePath"].ToString();
            else
                FILEPATH = ConfigurationManager.AppSettings["StorageRoot"];
            Directory.CreateDirectory(FILEPATH);
            return FILEPATH; 
        }
		public bool IsReusable { get { return false; } }
		public void ProcessRequest (HttpContext context) {
			context.Response.AddHeader("Pragma", "no-cache");
			context.Response.AddHeader("Cache-Control", "private, no-cache");
            if (context.Request.Params["Id"] != null && context.Request.Params["Field"] != null) {
                context.Session["fuFilePath"] = ConfigurationManager.AppSettings["StorageRoot"] + context.Request.Params["Id"] + "\\" + context.Request.Params["Field"] + "\\"; ;
            }
                 
			HandleMethod(context);
		}
