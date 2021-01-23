    public class JsonDataContractResult : ActionResult
    {
        public JsonDataContractResult(Object data)
        {
            this.Data = data;
        }
        protected JsonDataContractResult()
        {
            
        }
        public Object Data { get; private set; }
        
        public override void ExecuteResult(ControllerContext context)
        {
            Guard.ArgumentNotNull(context, "context");
            var serializer = new DataContractJsonSerializer(this.Data.GetType());
            String output; 
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, this.Data);
                output = Encoding.Default.GetString(ms.ToArray());
            } 
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.Write(output);
        }        
    }
