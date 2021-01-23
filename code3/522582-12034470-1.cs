     //Read Form data
     string testData = Request["SmsSid"] + " " + Request["SmsStaus"];
    
     //Prepare Json string - output
     Response.Clear();
     Response.ContentType = "application/json";
     Response.Write("{ \"d\": \"" + testData +"\" }");
     Response.Flush();
     Response.End();
