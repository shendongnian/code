    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
            const int CHECKBOX_COLUMN = 4;
            for (int i = 0; i < MyDataGrid.Items.Count - 1; i++)
            {
                DataGridCell cell = GetCell(i, CHECKBOX_COLUMN);
                CheckBox tb = cell.Content as CheckBox;
                MessageBox.Show(tb.IsChecked.ToString());
            }
    }
