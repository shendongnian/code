    public ObjectResult<OrderDetail> GetDetailsForOrder
     (Nullable<global::System.Int32> orderid)
    {
      ObjectParameter orderidParameter;
      if (orderid.HasValue)
      {
        orderidParameter = new ObjectParameter("orderid", orderid);
      }
      else
      {
        orderidParameter = new ObjectParameter("orderid", typeof(global::System.Int32));
      }
      return base.ExecuteFunction<OrderDetail>("GetDetailsForOrder", orderidParameter);
    }
