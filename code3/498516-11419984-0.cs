    public class UpdateOrderStatusInfo
    {
        public class Result
        {
            public int OrderNumber { get; set; }
            public string SellerID { get; set; }
            public string OrderStatus { get; set; }
        }
        public UpdateOrderStatusInfo()
        {
            Result = new Result();
        }
        public string IsSuccess { get; set; }
        public Result Result { get; set; }
    }
