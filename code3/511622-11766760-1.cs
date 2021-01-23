    public class OrderListResponseBody
    {
        public PageInfo PageInfo { get; set; }  
        public string RequestID { get; set; }  
        public string RequestDate { get; set; } 
        public List<OrderInfo> OrderInfoList { get; set; }  <!-- notice the change
    }
