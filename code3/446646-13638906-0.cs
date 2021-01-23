        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[3].ToString()) > 0)
                {
                    e.Row.Background = new SolidColorBrush(Colors.Green);
                }
                else if (Convert.ToDouble(((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[4].ToString()) < 0)
                {
                    e.Row.Background = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    e.Row.Background = new SolidColorBrush(Colors.WhiteSmoke);
                }
            }
            catch
            {
            } 
        }
