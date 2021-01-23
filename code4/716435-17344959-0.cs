    public async void UpdateDriverOnParse(Int32 ID)
            {
       
    
                var query = (from find in ParseObject.GetQuery("DriverLogin")
                             where find.Get<Int32>("SystemID") == ID
                             select find);
    
                // Retrieve the results
                IEnumerable<ParseObject> Data = await query.FindAsync();
    
                //for updating the selected row
                foreach (var row in Data)
                {
    
                    row["Pin"] = Convert.ToInt32(txtPinNo.Text);
                    row["DriverID"] = Convert.ToInt32(txtCallSign.Text);
                    row["Name"] = txtFirstName.Text+" "+txtMname.Text+" "+txtLastName.Text;
                    await row.SaveAsync();
    
                }
    }
