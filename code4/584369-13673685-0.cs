    var a = txtLot.Text;
    var b = cmbMcu.SelectedItem.ToString();
    var c = cmbLocn.SelectedItem.ToString();
    
    btnCheck.BackColor = Color.Red;
    var task = Task.Factory.StartNew(() => Dal.GetLotAvailabilityF41021(a, b, c));
    task.ContinueWith(t =>
    {
        btnCheck.BackColor = Color.Transparent;
        lblDescriptionValue.Text = t.Result.Description;
        lblItemCodeValue.Text = t.Result.Code;
        lblQuantityValue.Text = t.Result.AvailableQuantity.ToString();
    }, TaskScheduler.FromCurrentSynchronizationContext());
