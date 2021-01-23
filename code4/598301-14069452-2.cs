    public class Handler1: IHttpHandler
    {
       public void ProcessRequest(HttpContext context)
       {
          context.Response.ContentType = "application/json";
          var param1= context.Request.QueryString["param1"];
          //param1 value will be "someparam"
          // do something cool like filling a datatable serialize it with newtonsoft jsonconvert
          var dt= new DataTable();
          // fill it
          context.Response.Write(JsonConvert.SerializeObject(dt));
       }
    }
