    string strq2 = "WHERE 1=1";
    if(!string.IsNullOrEmpty(DropDownList1.SelectedItem.Text))
    strq2 += " AND [Year 1]=@Year1";
    if(!string.IsNullOrEmpty(DropDownList2.SelectedItem.Text))
    strq2 += " AND [Product]=@Product";
    if(!string.IsNullOrEmpty(DropDownList3.SelectedItem.Text))
    strq2 += " AND [Media]=@Media";
    if(!string.IsNullOrEmpty(DropDownList4.SelectedItem.Text))
    strq2 += " AND [Publication]=@Publication";
    if(!string.IsNullOrEmpty(DropDownList5.SelectedItem.Text))
    strq2 += " AND [Genre]=@Genre";
    if(!string.IsNullOrEmpty(DropDownList6.SelectedItem.Value))
    strq2 += " AND [Month]=@Month";
    if(!string.IsNullOrEmpty(DropDownList7.SelectedItem.Value))
    strq2 += " AND [Section]=@Section";
