    var results = new List<Products>(); //our new data source with only checked items
    
    foreach (DataGridViewRow row in productsDataGridView)
    {
        var check = row.Cells[ColPromotions.Index].Value as bool? ?? false; //here we check if column is checked
        if (check)
        {
             var item = row.DataBoundItem as Products; //get product from row (only when grid is databound!)
             results.Add(item);
        }
    }
    
    promotionsDataGridView.DataSource = results; 
