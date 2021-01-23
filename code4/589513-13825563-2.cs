    public class Document
    {
        private readonly IDataSource _dataSource;
        private readonly IWidgetRepository _widgetRepository;
        private readonly IWhatsitRepository _whatsitRepository;
        public Document (IDataSource dataSource, IWidgetRepository widgetRepository, IWhatsitRepository whatsitRepository)
        {
            _dataSource = dataSource;
            _widgetRepository = widgetRepository;
            _whatsitRepository = whatsitRepository;
        }
    }
