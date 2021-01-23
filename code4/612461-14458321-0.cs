    // Create a DataTable with a list of shipments.    
    DataTable dt = c.Query(c.qShipments(Row.Cells[0].Value.ToString()));
    // Check if there is at least one shipment
    if (dt.Rows.Count >= 1)
    {
        DataTable customDt = new DataTable();
    
        // Add the starting location (which is the same as the destination. It has to be at 
        customDt.Rows.Add(0, 0, 9999, textBox_CC.Text, textBox_PC.Text, textBox_SL.Text);
    
        foreach(DataRow row in dt.Rows)
        {
            customDt.ImportRow(row);
        }
        // Add the destination of the shipments
        customDt.ImportRow(customDt.Rows[0]);
    
        // Finally calculate and return the object to populate the datagridview with.
        dataGridView_CalculatedRoutes.Rows.Add(x.getRoute(dt));
    }
