    namespace MyApp.Contracts
    {
        public interface IModel {}
        public interface IViewModel {}
        public interface IDataMapperService<ViewModelT, ModelT>
            where ViewModelT : IViewModel
            where ModelT : IModel
        {
            ViewModelT ModelToViewModel(ModelT v);
        }
    }
