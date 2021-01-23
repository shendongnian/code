        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             // you can bind your data as per your requirement
            lstbxEmloyee.ItemsSource = GetTable().DefaultView; 
        }
        private void lstbxEmloyee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          DataRow dr=((DataRowView) (lstbxEmloyee.SelectedItem)).Row;
          int Emp_id = Convert.ToInt32(dr["employee_ID"]);
          MessageBox.Show(Emp_id.ToString());
        }
        DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("employee_ID", typeof(int));
            table.Columns.Add("employee_name", typeof(string));        
            table.Rows.Add(1,"David");
            table.Rows.Add(2,"Sam");
            table.Rows.Add(3,"Christoff");
            table.Rows.Add(4, "Janet");
            table.Rows.Add(5, "Melanie");
            return table;
        }     
