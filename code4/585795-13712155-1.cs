    public DeliveryType UserDeliveryType
    {
        get 
        {
            return (DeliveryType)Session["DeliveryType"];
        }
        set 
        {
            Session["UserDeliveryType"] = value;
        }
    }
