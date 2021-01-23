    private void cbBuscar_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (!IsLoaded)
            return;
        MessageBox.Show(cbBuscar.SelectedIndex.ToString());
        if (cbBuscar.SelectedIndex == 0)
        {
           cbProduto.Visibility = Visibility.Hidden;
        }
        else if (cbBuscar.SelectedIndex == 1)
        {
            cbProduto.Visibility = Visibility.Visible;
        }
        else if (cbBuscar.SelectedIndex == 2)
        {
            cbProduto.Visibility = Visibility.Collapsed;
        }
    }
