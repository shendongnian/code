    UpdateCustomerNameAndUpdateAllHisOrders(CustomerEntity customer)
    {
      //StartTransaction();
      CustomerDa.Update(customer);
      var orders = OrderService.GetAllOrders(customer);
      //Modify Orders logic
      OrderService.UpdateOrders(orders);
      //CommiteTransaction();
    }
