    public class BaseAppServ<TModel, TItem>: IBaseAppServ<TModel>
                where TItem : class, IEntity 
                where TModel: ICompanyFacility, new()
    {
        private Repository<TItem> _repository;
        private TModel _viewModel;
        private AuditStampsViewModel _auditStamps;
        public BaseAppServ(Repository<TItem> repository)
        {
            _repository = repository;
            _viewModel = new TModel();
            _auditStamps = new AuditStampsViewModel();
        }
