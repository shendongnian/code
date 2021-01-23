    public interface IWindowService
    {
        Result ShowWindow(InitArgs initArgs);
    }
    
    public sealed class WindowService : IWindowService
    {
        public Result ShowWindow(InitArgs initArgs);
        {
            //show window
            //return result
        }
    }
    
    public class CashViewModel 
    {
        private IWindowService m_WindowService;
        public CashViewModel(IWindowService windowService)
        {
            m_WindowService = windowService;
        }
    
        public RelayCommand HistoryCommand
        {
            get
            {
                return _historyCommand
                    ?? (_historyCommand = new RelayCommand(
                                          () =>
                                          {
                                              var result = m_WindowService.ShowWindow(args);
                                          }));
            }
        }
    }
