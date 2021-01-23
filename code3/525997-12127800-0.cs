        protected void Page_Load(object sender, EventArgs e)
         {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = ProfileMasterDAL.bindcountry();
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--Select country--");
                //get the selected country from another page
                string selectedCountry = Convert.ToString(Session["country"]);
                //set the selected value
                DropDownList1.Items.FindByValue(selectedCountry).Selected = true;
                //Bind Dropdonwlist2
                 BindDropDownList(DropDownList1.SelectedItem.Text);
            
            }
            /*
             remaining code
             */
        }
 
