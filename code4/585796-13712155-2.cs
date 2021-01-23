    public string ViewAddOn(string viewName)
    {
        return (UserDeliveryType != DeliveryType.Normal) ?
            string.Format("{0}.{1}", viewName, UserDeliveryType.ToString()) :
            viewName;
    }
