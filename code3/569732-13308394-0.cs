    private void button1_Click(object sender, RoutedEventArgs e)
    {
        DataTable oldTable = dataSet.Tables["Stores"].Copy();
        listView1.DataContext = oldTable.DefaultView;
        listView1.Items.Refresh();
        backWorker.RunWorkerAsync();
    }
