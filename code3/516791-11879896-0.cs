    public event EventHandler CustomerSelected { get; set; }
    private void OnCustomerSelected() {
        var customerSelected = CustomerSelected;
        if (customerSelected != null) {
            customerSelected(this, EventArgs.Empty);
        }
    }
