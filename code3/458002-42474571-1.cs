    public class JQGridHandler : IHttpHandler
        {
            History myHistory = new History();    
    
            public void ProcessRequest(HttpContext context)
            {
                try {                   
        List<HistoryDetails> myHistoryDetails = new List<HistoryDetails>();
                myHistoryDetails = myHistory.GetAllHistoryDetails();
                var jsonSerializer = new JavaScriptSerializer();   
             context.Response.Write(jsonSerializer.Serialize(myHistoryDetails));
                }
                catch(Exception ex)
                {
                   
                }
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
