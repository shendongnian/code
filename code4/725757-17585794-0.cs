       [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static string CheckUserName(string userName)
        {
            var sql = new SqlHelper();
            string returnValue = string.Empty;
            try
            {
                if (Regex.IsMatch(userName, @"^[A-Za-z0-9._]{1,20}$"))
                {
                    returnValue = sql.GetUser(userName) != null & userName != null ? "false" : "true";
                }
                else
                {
                    returnValue = "error";
                }
            }
            catch
            {
                returnValue = "false";
            }
            return returnValue;
        }
