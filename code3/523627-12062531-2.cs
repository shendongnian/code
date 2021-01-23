        public string MyProperty
        {
            get
            {
                return ViewState["MyProperty"] as string;
            }
            set
            {
                ViewState["MyProperty"] = value;
            }
        }
