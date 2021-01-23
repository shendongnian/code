        private void BindDataToGrid()
        {
            //Sample Data
            List<Employee> empList =new List<Employee>();        
            empList.Add(new Employee(){FirstName = "Rob", LastName="Cruise"});
            empList.Add(new Employee() { FirstName = "Lars", LastName = "Fisher" });
            empList.Add(new Employee() { FirstName = "Jon", LastName = "Arbuckle" });
            empList.Add(new Employee() { FirstName = "Peter", LastName = "Toole" });
        
            DataGridTextColumn data_column = new DataGridTextColumn();
            data_column.Binding = new Binding("FirstName");
            data_column.Header = "First Name";
            showgrid.Columns.Add(data_column);
            data_column = new DataGridTextColumn();
            data_column.Binding = new Binding("LastName");
            data_column.Header = "Last Name";
            showgrid.Columns.Add(data_column);
            showgrid.ItemsSource = empList;
            showgrid.AutoGenerateColumns = false;
        }
        private class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
