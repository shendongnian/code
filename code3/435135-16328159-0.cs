    private void button2_Click(object sender, RoutedEventArgs e)
    {
         LoadOperation<Employees> loadOpKKM = this._employeeContext.Load(this._employeeContext.GetEmployeeByIDQuery(1));
         loadOpKKM.Completed += new EventHandler(loadOpKKM_Completed);
    }
    
    void loadOpKKM_Completed(object sender, EventArgs e)
    {
         LoadOperation<Employees> loadOpKKM = (LoadOperation<Employees>)sender;
         if(loadOpKKM != null)
         {
             MessageBox.Show(loadOpKKM.Entities.Count().ToString());
         }
         else
         {
             //TODO
         }
    }
