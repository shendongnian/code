    protected void btnTextDisplay_Click(object sender, EventArgs e)
        {
           List<string> list;
    
            if (Session["list"] == null)
            {
                list = new List<string>();
            }
            else
            {
                list = (List<string>)Session["list"];
            }
    
            list.Add(txtName.Text + "," + txtCity.Text); //store textbox values in the array list
            Session["list"] = list;
    
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("City");
    
            for (int i = 0; i < list.Count; i++)
            {
                string[] arrVal;
                arrVal = list[i].ToString().Split(',');
                dt.Rows.Add(arrVal[0], arrVal[1]);
            }
    
            gvDisplay.DataSource = dt;
            gvDisplay.DataBind();
        }
