    namespace Nop.Services.Orders {
    
      public partial class OrderProcessingService : IOrderProcessingService {
    
        partial void PlaceOrder(ProcessPaymentRequest processPaymentRequest,
          ref PlaceOrderResult result);
