    private void OnProcessNewValue_Double(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e) 
    {
        ObservableCollection<double> source = (ObservableCollection<double>)(sender as LookUpEdit).Properties.DataSource;
        if (source != null) {
            if ((sender as LookUpEdit).Text.Length > 0) {
                double val = Convert.ToDouble((sender as LookUpEdit).Text);
                source.Add(val);
                e.DisplayValue = val;
                (sender as LookUpEdit).Refresh();
            }
        }        
        e.Handled = true;
    }
