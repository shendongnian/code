    interface IOrder
    {
      GetSubmittedOrder();
      CreateOrder();
      GetExistingOrder();
    }
    
    interface ISpecificOrder
    {
      GetSubmittedOrder();
      CreateOrder();
      GetExistingOrder();
    }
    
    Class Order : IOrder, ISpecificOrder
    {
      BuildSpecialOrder();
      AddSpecialOrderParameters();
      IOrder.GetSubmittedOrder();
      IOrder.CreateOrder();
      IOrder.GetExistingOrder();
      ISpecificOrder.GetSubmittedOrder();
      ISpecificOrder.CreateOrder();
      ISpecificOrder.GetExistingOrder();
    
    }
    
