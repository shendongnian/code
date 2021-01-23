    public OrderCollection GetAllClickCollectOrders
    {
        get
        {
            if(Session["OrderCollection"] == null)
            {
                Session["OrderCollection"] = GetClickCollectOrderDetails(Session["SelectedStorePostCode"].ToString());
             return Session["OrderCollection"] as OrderCollection;
        }
    }
