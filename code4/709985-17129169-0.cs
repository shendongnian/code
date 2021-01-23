    public static class Helper
    {
        public static string[] CheckBoxes
        {
            get
            {
                string [] result = System.Web.HttpContext.Current.Session["CheckBoxId"] as string[];
                if (result == null)
                {
                    result = new string[] { };
                }
                return result;
            }
            set
            {
                System.Web.HttpContext.Current.Session["CheckBoxId"] = value;
            }
        }
    }
