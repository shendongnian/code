    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Operate op = new Operate();
        DataTable users = op.GetUser();
        if (users != null)
        {
            ResultsView.ItemsSource = users.DefaultView;
        }
    }
    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ResultsView.SelectedItem != null)
        {
            DataRowView line = ResultsView.SelectedItem as DataRowView;
            string stuff = line.Row.ItemArray[2].ToString();
            MessageBox.Show(stuff);
        }
    }
