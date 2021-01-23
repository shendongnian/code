    if (lstSalesGroup.SelectedItem != null)
    {
        selectQuery.Append("AND SALES_GROUP IN (");
        var local = lstSalesGroup.Items.Where(c => c.Selected)
                           .Select(c => "'"+c.Value+"'")
                           .Aggregate((c,n) => c+ ", "+n);
    
       selectQuery.Append(local);            
       selectQuery.Append(")");
    }
