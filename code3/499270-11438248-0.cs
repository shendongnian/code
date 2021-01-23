        protected decimal? IdSubCategory
        {
            get
            {
                if (Session["SubCategory"] == null)
                    return null;
                else
                    return decimal.Parse(Session["SubCategory"].ToString());
            }
            set
            {
                Session["SubCategory"] = value;
            }
        }
