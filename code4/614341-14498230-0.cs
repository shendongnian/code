    private string collectOrders = String.Empty;
    
    public OrderCollection GetAllClickCollectOrders
    {
        get
        {
            if(String.IsNullOrEmpty(collectOrders)
                 collectOrders = GetClickCollectOrderDetails(Session["SelectedStorePostCode"].ToString());
            return collectOrders;
        }
    }
