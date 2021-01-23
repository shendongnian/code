    private void BindList()
    {
        ProfileMasterBLL bll=new ProfileMasterBLL();
        foreach (var VARIABLE in ProfileMasterDAL.bindcountry())
        {
          if (VARIABLE.ToString().Contains(DropDownList1.SelectedItem.Text))
          {
             var query = 
           ProfileMasterDAL.GetStatesByCountrys(DropDownList1.SelectedItem.Text));
                        DropDownList2.DataSource = query;
                        DropDownList2.DataBind();
          }
    }
