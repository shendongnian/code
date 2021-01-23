        public static int GetProcessed()
        {
            int result = 0;
            int.TryParse(HttpContext.Current.Session["processed"].ToString()), out result);
            return result;
        }
