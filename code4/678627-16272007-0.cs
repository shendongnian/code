    grid1.Children.Clear();
    grid1.RowDefinitions.Clear();
    grid1.ColumnDefinitions.Clear();
                
    //Adding columns to datagrid
    ColumnDefinition gridCol1 = new ColumnDefinition();
    ColumnDefinition gridCol2 = new ColumnDefinition();
    grid1.ColumnDefinitions.Add(gridCol1);
    grid1.ColumnDefinitions.Add(gridCol2);
    // Add first column header
    TextBlock txtBlock1 = new TextBlock();
    txtBlock1.Text = "Particulars";
    txtBlock1.FontSize = 14;
    txtBlock1.FontWeight = FontWeights.Bold;
    txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
    txtBlock1.VerticalAlignment = VerticalAlignment.Top;
    Grid.SetRow(txtBlock1, 0);
    Grid.SetColumn(txtBlock1, 0);
    // Add second column header
    TextBlock txtBlock2 = new TextBlock();
    txtBlock2.Text = "Amount";
    txtBlock2.FontSize = 14;
    txtBlock2.FontWeight = FontWeights.Bold;
    txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
    txtBlock2.VerticalAlignment = VerticalAlignment.Top;
    Grid.SetRow(txtBlock2, 0);
    Grid.SetColumn(txtBlock2, 1);
    //// Add column headers to the Grid
    grid1.Children.Add(txtBlock1);
    grid1.Children.Add(txtBlock2);
    RowDefinition gridRow = new RowDefinition();
    grid1.RowDefinitions.Add(gridRow);
    TextBlock par;
    TextBox amt;
    int i = 1;
    string pjt = comboBox1.SelectedItem.ToString();
               
               
    //Display all the Particulars
    SqlCeConnection con;
    con = dbConnection();
    SqlCeCommand cmd;
    string sql = "select * from " + pjt;
    try
    {
        cmd = new SqlCeCommand(sql, con);
        SqlCeDataReader rdr = cmd.ExecuteReader();
        int ordName = rdr.GetOrdinal("Name");
        while (rdr.Read())
        {
            string nam = rdr.GetString(ordName);
            gridRow = new RowDefinition();
            gridRow.Height = new GridLength(45);
            grid1.RowDefinitions.Add(gridRow);
            par = new TextBlock();
            par.Text = nam;
            par.FontSize = 12;
            par.FontWeight = FontWeights.Bold;
            Grid.SetRow(par, i);
            Grid.SetColumn(par, 0);
            amt = new TextBox();
            amt.Height = 20;
            amt.Width = 190;
            amt.Foreground = new SolidColorBrush(Colors.Black);
            Grid.SetRow(amt, i);
            Grid.SetColumn(amt, 1);
            grid1.Children.Add(par);
            grid1.Children.Add(amt);
            i++;
        }                   
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex);
    }
