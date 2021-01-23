    DataGridViewTextBoxColumn vendorIDColumn =
           new DataGridViewTextBoxColumn()
           {
               MinimumWidth = 50,
               FillWeight = 20,
               DataPropertyName = "VendorID",
               HeaderText = "Vendor ID",
               AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
               BackColor = Color.Red;
           };
        grid.Columns.Add(vendorIDColumn);
