    protected void ddlTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlThree.Items.Clear();
            if (ddlTwo.SelectedValue != "0")
            {
                Contact.CategoriesDataTable table;
                ddlThree.AppendDataBoundItems = true;
                ddlThree.Items.Add(new ListItem("Choose", "0"));
                CategoriesTableAdapter subM = new CategoriesTableAdapter();
                int CategoryID = Convert.ToInt32(ddlTwo.SelectedValue); //This is where I get the error
                table = subM.GetCategoryByCategoryID(CategoryID);
                foreach (Contact.CategoriesRow row in table)
                {
    
    
                    string text = row.Category;
                    string value = row.CategoryID.ToString();
                    ddlThree.Items.Add(new ListItem(text, value));
    
                }
            }
        }
