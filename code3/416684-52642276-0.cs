    Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
    foreach (DataGridViewRow Row in Grid.Rows) 
    {
       if (......) 
       {
         Row.Visible = false;
       }
    }
    Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
