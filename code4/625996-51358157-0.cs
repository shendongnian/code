     DataTable dt = new DataTable();
        dt = (DataTable)dgvUom.DataSource;
        string firstColumn = txtUomtyp.Text;
        string secondColumn = cbxVNo.Text;
        string[] row = { firstColumn, secondColumn };
        dGVInventory.Rows.Add(row);
                   
