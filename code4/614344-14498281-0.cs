    OrderCollection _GetAllClickCollectOrders = null;
    bool goToDB = false;
    public OrderCollection GetAllClickCollectOrders
    {
        get
        {
             if(_GetAllClickCollectOrders == null || goToDB)
            _GetAllClickCollectOrders = GetClickCollectOrderDetails(Session["SelectedStorePostCode"].ToString());
    
             return _GetAllClickCollectOrders;
    
        }
    }
