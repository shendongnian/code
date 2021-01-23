    public class Order {
      public void RequestQuantity(int quantity, UserType userType)
      {
        this.RequestedQuantity = quantity;
      }
      public void ApproveToLowerOrEqualQuantity(int quantity) {
        if (quantity <= this.ApprovedQuantity)
        {
          // Requester type user can only update if lowering the approved quantity
          this.ApprovedQuantity = quantity;
        }
      }
      public void ApproveToHigherOrEqualtQuantity(int quantity) {
        if (quantity >= this.ApprovedQuantity)
        {
          // Supplier type user can only update if increasing the approved quantity
          this.ApprovedQuantity = quantity;
        }
      }
    }
    //Calling code
    public class ApplicationServiceOfSomeSort {
       public void RequestQuantity(UserId userId, OrderId orderId, int quantity) {
         var requester = requesterRepository.FromUser(userId);
         requester.MustBeAbleToRequestQuantity();
         var order = orderRepository.GetById(orderId);
         order.RequestQuantity(quantity);
       }
       public void ApproveQuantityAsRequester(UserId userId, OrderId orderId, int quantity) {
         var requester = requesterRepository.FromUser(userId);
         requester.MustBeAbleToApproveQuantity();
         var order = orderRepository.GetById(orderId);
         order.ApproveToLowerOrEqualQuantity(quantity);
       }
       public void ApproveQuantityAsSupplier(UserId userId, OrderId orderId, int quantity) {
         var supplier = supplierRepository.FromUser(userId);
         supplier.MustBeAbleToApproveQuantity();
         var order = orderRepository.GetById(orderId);
         order.ApproveToHigherOrEqualQuantity(quantity);
       }
    }
