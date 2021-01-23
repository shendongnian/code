    private void button2_Click(object sender, RoutedEventArgs e)
    {
         LoadOperation<Employees> loadOpKKM = this._employeeContext.Load(this._employeeContext.GetEmployeeByIDQuery(1));
         loadOpKKM.Completed += new EventHandler(loadOpKKM_Completed);
    }
    
    void loadOpKKM_Completed(object sender, EventArgs e)
    {
         MessageBox.Show(loadOpKKM.Entities.Count().ToString());
    }
    [Query(IsComposable=false)]
    public Employees GetEmployeeByID(int employeeID)
    {
        return this.ObjectContext.Employees.Single(c => c.EmployeeID == employeeID);
    }
