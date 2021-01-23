      protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
                LoadList();
        }
        
        private void LoadList()
        {
            int categoryId = Http.PrmIntOrZero["CategoryId"];
            string search = Http.PrmOrEmpty["Search"];
        
            DataRow c = DBCategory.GetOrNull(categoryId);
            if (c == null)
            {
                Response.Redirect("~/", true);
                return;
            }
        
            TitleC.Text = (string)c["Name"];
            Description.Text = System.Convert.ToString(c["Description"]);
        }
