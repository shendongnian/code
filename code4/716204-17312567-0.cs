    public class BaseViewModel
    {
        public LoginModel LoginModel { get; set; }
    }
    
    public class ComplexViewModel : BaseViewModel
    {
        public CartModel CartModel { get; set; }
    }
