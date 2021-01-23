        private void dtaResultGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ActivateTestDatagridAccess();
        }
        public async void ActivateTestDatagridAccess()
        {
            try
            {
                await Task.Delay(500);
                foreach (System.Data.DataRowView dr in dtaResultGrid.ItemsSource)
                {
                    for (int j = 0; j < dtaResultGrid.Columns.Count; j++)
                    {
                        Console.WriteLine(dr[j].ToString());
                    }
                    Console.Write(Environment.NewLine);
                }
            }
            catch (Exception exrr)
            {
                Console.WriteLine(exrr.ToString());
            }
        }
