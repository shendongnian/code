    string brandText = lvModels.SelectedItems[0].SubItems[1].Text;
    DataRow itemToSelect = ((DataTable) this.cbBrand.DataSource)
                              .Rows
                              .Cast<DataRow>()
                              .FirstOrDefault(r=>r.Field<string>("name").Equals(brandText));
    if(itemToSelect != null)
       cbBrand.SelectedItem = itemToSelect;
