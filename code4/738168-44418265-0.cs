        public static int GetQueryStringData()
        {
         if (HttpContext.Current.Request.QueryString["UserId"] != null)
          {
            return Convert.ToInt32(HttpContext.Current.Request.QueryString["UserId"]);
          }
         else
          {
            return 0;
          }
        }
        [WebMethod]
        public static string GetData()
        {
            int x = GetQueryStringData();
            if (x != 0)
                return "Success";
            else
                return "not success";
        }
