    void workerCustomers_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage; // Customers
        progressBar2.Value = (int)e.UserState; // Locations
    }
