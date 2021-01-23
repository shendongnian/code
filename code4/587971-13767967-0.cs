        protected void Button6_Click( object sender , EventArgs e )
    {
        string categoryToCreate = CreateCategory.Text;
    
        if(categoryToCreate != string.Empty)
        {
            CategoryCreateName.Visible = false;
            DataAccess.insertDataItem(categoryToCreate);
            CategoryList.Items.Clear();
            CategoryList.DataBind(); 
        }else
        {
            CategoryCreateName.Visible = true;
        }
    }
