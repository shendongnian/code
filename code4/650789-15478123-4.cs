    public interface IGetData {
      string GetData(parameters ...);
    }
    public class MyUserControl : UserControl, IGetData {
      ...
    }
