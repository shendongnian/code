    if (invoiceQty.FirstOrDefault() != null) return;
    
    if (Convert.ToInt32(txtReturnProdQty.Text) > (decimal)invoiceQty.First())
    {
        args.IsValid = false;
        SourceValidate.ErrorMessage = "Returned qty cannot be greater than quantity available on the invoice.";
        txtReturnProdQty.Focus();
        return;
    }
