    private bool ReadAndValidatePrice(out double price)
    {
        price = 0.0;
    
        if (!InputUtility.GetDouble(txtPrice.Text, out price))
        {
    
        }
    }
