    public OrderCollection GetAllClickCollectOrders {
      get {
        return m_allClickCollectOrders.Value;
      }
    }
    private Lazy<OrderCollection> m_allClickCollectOrders = new Lazy<OrderCollection>(
      () => GetClickCollectOrderDetails(Session["SelectedStorePostCode"].ToString())); 
