    public class mytest: System.Web.Services.WebService
        {
            [WebMethod (EnableSession = true)]
            public string HelloWorld()
            {
               //your logic here
                if(strDate!=null)
                      Session["ProcessStartTime"] = strDate;
                else
                     // handle if ur strDate is null
             }
        }
