    private void PopulateDataGridView()
    {
         blvManufacturers = new BindingListView<Manufacturer>(ManufacturerService.GetAll(_ctx));
        _bsManufacturers = new BindingSource { DataSource = _blvManufacturers};
        dgvManufacturers.DataSource = _bsManufacturers;         
    }
    private void FilterData(string str)
    {
        // Change the filter of the view.
          blvManufacturers.ApplyFilter(
            delegate(Manufacturer manu)
            {
                // uses ToLower() to ignore case of text.
                return manu.Name.ToLower().Contains(str.ToLower());
            }
        );           
    }
