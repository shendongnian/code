    class DALClass
    {
        private static object instanceLock = new object();
        public static DALClass Instance
        {
            get
            {
                if (Session["DALInstance"] == null)
                {
                    lock (instanceLock)
                    {
                        if (Session["DALInstance"] == null)
                        {
                            Session["DALInstance"] = new DALClass();
                        }
                    }
                }
                return (DALClass)Session["DALInstance"];
            }
        }
    }
