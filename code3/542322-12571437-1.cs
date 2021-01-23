    public bool CheckCondition1(object ID)
    {
        return ID.ToString() != "2";
    }
    public bool CheckCondition2(object ProductName)
    {
        return ProductName.ToString() != "jklö";
    }
    public string GetValue(object ID)
    {
        // check condition here       
        //    ...
        // and return according value
        return ID.ToString() + " is your ID";
        
        // eg
        //if (Condition1))
        //    return dtrCurrentRow["SellingPaymentMethod"].ToString();
        //else if (Condition 2)
        //    return dtrCurrentRow["DeliveryPaymentmethod"].ToString();
    }
    public string GetValue(object ID, object firstValue, object secondValue)
    {      
        if (ID.ToString() == "2")
            return firstValue.ToString();
        else
            return secondValue.ToString();
    }
