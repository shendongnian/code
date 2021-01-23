        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/x-javascript";
            //fetch data from database.
            //return data by writing the serialized objects directly to context.Response.OutputStream
        }
