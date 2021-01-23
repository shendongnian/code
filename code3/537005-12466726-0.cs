    public class MainPresenter
    {
      // Private variables
      private readonly IMainView _view;
      // Constructor
      public MainPresenter(IMainView view)
      {
        _view = view;
      }
      // Properties
      public IMainView View
      {
        get { return _view; }
      }
    }
