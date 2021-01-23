        private bool IsUCPostBack
        {
            get
            {
                object o = ViewState["S2UC"];
                return o == null;
            }
            set
            {
                ViewState["S2UC"] = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUCPostBack)
            {
                IsUCPostBack = true; ... } else { ...   }
   
