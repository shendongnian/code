        public string CurrentControlToLoad
        {
            get
            {
                 if(ViewState["controlType"] == null)
                     return "";
                 return (string)ViewState["controlType"];
            }
            set
            {
                 ViewState["controlType"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(CurrentControlToLoad != "")
               LoadControl(CurrentControlToLoad);
        }
        protected void btnAddSector_Click(object sender, DirectEventArgs e)
        {
            CurrentControlToLoad = "AddSector";
            LoadControl(CurrentControlToLoad);
        }
