        public List<string> MyList
        {
            get
            {
                if (ViewState["Items"] == null)
                    ViewState["Items"] = new List<string>() ;
                return (List<string>)ViewState["Items"];
            }
            set
            {
                ViewState["Items"] = value;
            }
        }
