    public void bindcategory()
    {         
        DataTable dt = new BALCate().GetCate();        
        DropDownList dropdownlist = new DropDownList();
        //SET AutoPostBack = true and attach an event handler for the SelectedIndexChanged event. This event will fire when you change any item in the category dropdown list.
        dropdownlist.AutoPostBack = true;
        dropdownlist.SelectedIndexChanged += new EventHandler(dropdownlist_SelectedIndexChanged);
        foreach (DataRow dr in dt.Rows)
        {
            ListItem listitem = new ListItem();
            listitem.Text = dr["cate_name"].ToString();
            listitem.Value= dr["cate_id"].ToString();
            dropdownlist.Items.Add(listitem);            
        }
        cate_search.Controls.Add(dropdownlist);
    }
    
    void dropdownlist_SelectedIndexChanged(object sender, EventArgs e){
        //Grab the selected category id here and pass it to the bindSubCategory function.
        bindSubCategory(Convert.ToInt32((sender as DropDownList).SelectedValue)); 
    }
    
    public void bindsubcategory(int categoryId)
    {
         DataTable dt = new BALCate().GetSubCate(categoryId);
         //Bind this data to the subcategory dropdown list 
    }
