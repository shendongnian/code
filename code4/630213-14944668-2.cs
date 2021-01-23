    public interface IRegisterViewModel
    {
        public string Name { get; set;}
        public ... Identity {get; set;}
        ...
    }
    
    public class RegisterViewModel : IRegisterViewModel
    {
        ...
    }
    
    public class RegisterSellerViewModel : IRegisterViewModel
    {
        ...
    }
