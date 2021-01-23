    public interface IProvideCurrentIdentityRoles
    {
       bool CanRequestQuantity()
       bool CanApproveQuantity();
       bool CanOverruleQuantityOnSubmittedOrder();
       bool CanIncreaseQuantityOnFinalOrder();
       bool CanDecreaseQuantityOnFinalOrder();
    }
    
    public class Order
    {
        public int OrderId {get; private set}
        public int RequestedQuantity {get; private set}
        public int ApprovedQuantity {get; private set}
    
        public void RequestQuantity(int quantity, IProvideCurrentIdentityRoles requester)
        {
            Guard.That(requester.CanRequestQuantity());
            this.RequestedQuantity = quantity;
        }
    
        public void ApproveQuantity(int quantity, IProvideCurrentIdentityRoles  approver)
        {
            if (quantity == this.RequestedQuantity)
            {
               Guard.That(approver.CanApproveQuantity());
            }
            else 
            {
               if (orderType == OrderType.Submitted)
               {
                  Guard.That(approver.CanOverruleQuantityOnSubmittedOrder());
               }
               else if (orderType == OrderType.Final)
               {
                  if (quantity > this.ApprovedQuantity)
                  {
                     Guard.That(approver.CanIncreaseQuantityOnFinalOrder());
                  }
                  else 
                  {
                     Guard.That(approver.CanDecreaseQuantityOnFinalOrder());
                  }
               }
            }
            this.ApprovedQuantity = quantity;
         }
    }
