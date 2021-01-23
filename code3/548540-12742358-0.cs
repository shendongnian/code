    var row = adminDT.NewRow();
    row[0] =  tbxAdminProductName.Text;
    row[1] =  tbxAdminProductID.Text;
    row[2] =  tbxAdminDate.Text;
    row[3] =  tbxAdminQuantity.Text;
    row[4] =  tbxAdminCostPrice.Text;
    row[5] =  tbxAdminSellingPrice.Text;
    
    adminDT.Rows.Add(row);
    adminDS.Tables.Add(adminDT);
    adminDS.WriteXml("stockDetails.xml");
