    lstView.Columns.Add("Town");
    lstView.Columns.Add("Year");
    lstView.Columns.Add("Population");
    lstView.View = View.Details;
    ListViewItem item = new ListViewItem(new []{txtTownName.Text,txtYearEstablished.Text,txtPopulation.Text});
    lstView.Items.Add(item);
    
