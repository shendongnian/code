    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        switch (e.Name)
        {
            case nameof(Client.name):
                e.Column.Header = "Name";
                break;
            case nameof(Client.claim_number):
                e.Column.Header = "Claim Number";
                break;
        }
    }
