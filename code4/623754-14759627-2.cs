    namespace MyApp.Contracts
    {
        public interface IDataMapperService<ViewModelT, ModelT>
        {
            ViewModelT ModelToViewModel(ModelT v);
        }
    }
