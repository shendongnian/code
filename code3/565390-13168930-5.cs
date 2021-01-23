    public static string Login(string Email, string Password)
    {
        try
        {
            string postData = "{" + "\"Email\":\"" + Email + "\"," +
            "\"Password\":\"" + Password + "\"" +
            "}";
            string JsonResult = JsonPost("Your Web Service URL", "Login", postData);
            return JsonResult;
        }
        catch (Exception ex)
        {
            
            return "";
        }
    }
