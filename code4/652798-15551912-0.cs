    //copy current data table
    DataTable cloneTable = dt.Copy();
    ddlEventhistory.Items.Add(new Data { Name = DateTime.Now.ToString(), Value = cloneTable }); 
    ddlEventhistory.DisplayMember = "Name";
    ddlEventhistory.ValueMember = "Value";
