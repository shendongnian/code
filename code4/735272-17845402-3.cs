    if (!Page.IsPostBack)
        {
            string path = @"C:\Websites\TaxMapCS";
            DirectoryInfo di = new DirectoryInfo(path);
            FileSystemInfo[] fi = di.GetFiles("*.aspx");
            var result = string.Join(",", fi.OrderByDescending(f => f.CreationTime).Select(i => i.ToString()).ToArray());
    
            DropDownList1.DataSource = result.Replace(".aspx", "").Split(',');
    
            DropDownList1.DataBind();
    
            DropDownList1.Items.Insert(0, new ListItem("Select Edition", ""));
            DropDownList1.Items.Insert(0, new ListItem(Page.Title, ""));
    
        }
    }
    
    
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex > 0)//do not redirect if 'Selected Edition' is selected
            {
                Response.Redirect(DropDownList1.SelectedItem.Text + ".aspx");
            }
        }
