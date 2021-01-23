    private void dgvMailingList_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        e.Column.CellStyle = new Style(typeof(DataGridCell));
        e.Column.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty,  new SolidColorBrush(Colors.LightBlue)));
    }
