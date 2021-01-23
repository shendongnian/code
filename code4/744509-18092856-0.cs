        protected void Page_Load(object sender, EventArgs e)
                {
                    if (!IsPostBack)
                    {
                        BindGridview();
                    }
                }
    
            // Single Dimensional array
            private void BindGridview()
            {
                string[] arrlist = // your function that gets the arraylist
                DataTable dt = new DataTable();
                // you need to do the following for each column
                dt.Columns.Add("Name");
                for (int i = 0; i < arrlist.Count(); i++)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = arrlist[i].ToString();
                }
                gvarray.DataSource = dt;  //gvarray is your GridView defined in aspx design
                gvarray.DataBind();
            } 
 
