        public static Int32 MyInt
        {
            get
            {
                return (Int32)HttpContext.Current.Session["MyInt"];
            }
            set
            {
                HttpContext.Current.Session["MyInt"] = value;
            }
        }
