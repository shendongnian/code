      public class clsSession
        {
            public static DataTable dtEmp
            {
                get
                {
                    if (HttpContext.Current.Session["dtEmp"] != null)
                    {
                        return (DataTable)HttpContext.Current.Session["dtEmp"];
                    }
                    else
                        return new DataTable();
                }
                set
                {
                    HttpContext.Current.Session["dtEmpAddres"] = value;
                }
            }
        }
