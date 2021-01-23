    public class UpdateOrderStatusInfo
    {
        public class UpdateOrderResult
        {
            public int OrderNumber { get; set; }
            public string SellerID { get; set; }
            public string OrderStatus { get; set; }
        }
        public UpdateOrderStatusInfo()
        {
            Result = new UpdateOrderResult();
        }
        public string IsSuccess { get; set; }
        public UpdateOrderResult Result { get; set; }
    }
