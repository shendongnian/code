        private void simpleDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "SomeProperty")
                e.Cancel = true;
        }
