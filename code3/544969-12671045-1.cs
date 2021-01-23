    public void InvoiceID_TextChanged(object obj, RoutedEventArgs e)
        {
            OrderViewModel ovm = obj as OrderViewModel;
            string invoiceIDText = (e.OriginalSource as TextBox).Text;
            foreach (OrderViewModel o in NewOrders)
            {
                if (o.ID == ovm.ID)
                {
                    o.InvoiceNumber = invoiceIDText;
                }
            }
        }
