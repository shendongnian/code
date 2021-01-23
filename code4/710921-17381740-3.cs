    public class vm : IDataErrorInfo, INotifyPropertyChanged
    {
        private readonly IEntityStateProvider _stateProvider;
    
        public vm(IEntityStateProvider stateProvider)
        {
            _stateProvider = stateProvider;
            _stateProvider.Save(this);
        }
        ............
    }
