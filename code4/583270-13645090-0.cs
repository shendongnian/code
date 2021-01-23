    public interface IViewModel{
      string name {get;set;}
    }
    public class TblProduct: IVievModel{
     /// your code
    }
    public class TblCategory: IVievModel{
     /// your code
    }
    public class Bar{
     private Dictionary<string, IViewModel> viewModels = new Dictionary<string,IViewModel>();
    }
