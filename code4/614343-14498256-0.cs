    private OrderCollection AllClickCollectOrders;
    
    public OrderCollection GetAllClickCollectOrders
    {
        get
        {
            if(AllClickCollectOrders == null)
            {
               AllClickCollectOrders = GetClickCollectOrderDetails(Session["SelectedStorePostCode"].ToString());
            }
            return AllClickCollectOrders;
        }
    }
