    private void OrdersButton_Click(object sender, EventArgs e)
    {
        bool value = (OrdersButton.Tag as bool?) ?? true;
        OrdersButton.Tag = !value;
        OrdersButton.Text = "Turn Orders " + (value ? "On" : "Off");
    }
