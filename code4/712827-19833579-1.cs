     String callBack = Request["callback"];
     if (callBack != null)
                {
    
                    Response.Write(callBack + "(" + GetDataTableToJSONString(GetDiamonds(paramList)) + ")");
                }
                else
                    Response.Write(GetDataTableToJSONString(GetDiamonds(paramList)));
