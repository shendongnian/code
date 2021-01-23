        [WebMethod(EnableSession = true)]
        public static void SomeWebMethod()
        {
            if (System.Web.HttpContext.Current.Session["SomeSessionVar"] == null)
            {
                throw new Exception("ERROR: Session has Expired");
            }
        }
