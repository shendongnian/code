    private void dataGridAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
      if (e.PropertyName.StartsWith("MyColumn")
        e.Column.Header = "Anything I Want";
    }
