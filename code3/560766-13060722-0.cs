if (string.IsNullOrEmpty(lblCustomerName.Text)) { 
    btnCustomer.Visibility = Visibility.Hidden;
} 
else {
    btnCustomer.Visibility = Visibility.Visible;
}
