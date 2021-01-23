     private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
            {
                MyData = CollectionViewSource.GetDefaultView(t_KlantenDataGrid.ItemsSource);
                TextBox t = sender as TextBox;
                SearchText = t.Text.ToString();
                MyData.Filter = FilterData;
            }
