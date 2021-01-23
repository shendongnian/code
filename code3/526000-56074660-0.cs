        protected void Page_Load(object sender, EventArgs e)
         {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = ProfileMasterDAL.bindcountry();
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--Select country--");
    
                if(Session["uname"]!=null)
                {
                    DropDownList1.SelectedValue = Session["country"].ToString();
                    BindList()
                }
    
            }
            if(Session["uname"]!=null)
            {
                TextBox8.Text = Session["email"].ToString();
                string pwd = Session["pwd"].ToString();
                TextBox9.Attributes.Add("value",pwd);
                TextBox10.Attributes.Add("value", pwd);     
            }
         }
    
