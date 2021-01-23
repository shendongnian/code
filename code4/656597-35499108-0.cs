     - This might be late,but i'm posting the solution as it can help you or others
     - As you are able to reach your webmethod, you need to modify your webmethod to read the data from the object as follows
    
        [System.Web.Services.WebMethod]
        public static string saveDataToServer(Dictionary<string, string> csObj)
         {
                try
                {
                     string Name = csObj["cntName"].ToString();
                     string Email = csObj["cntEmail"].ToString();
                     //you can read values like this and can do your operation
                     return "";//return your value
                }
                catch(Exception ex)
                {
                      throw new Exception(Ex.Message);
                }
         }
    
       
