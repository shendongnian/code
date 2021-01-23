    class Program
    {
        static void Main(string[] args)
        {
            var myOrder = new UpdateOrderStatusInfo();
            myOrder.IsSuccess = "true";
            myOrder.OrderResult.OrderNumber = 1001;
            myOrder.OrderResult.OrderStatus = "Pending";
            myOrder.OrderResult.SellerID = "69";
        }
    }
    public class UpdateOrderStatusInfo
    {
        public string IsSuccess { get; set; }
        public Result OrderResult { get; set; }
        public UpdateOrderStatusInfo()
        {
            OrderResult = new Result();
        }
    }
    public class Result
    {
        public int OrderNumber { get; set; }
        public string SellerID { get; set; }
        public string OrderStatus { get; set; }
    }
