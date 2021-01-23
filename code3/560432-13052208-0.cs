    public class BaseResponse
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
    }
    public class DrinkResponse : BaseResponse
    {
        public Drink[] drinks { get; set; }
    }
    public class SnackResponse : BaseResponse
    {
        public Snack[] snacks { get; set; }
    }
