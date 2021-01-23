    // Assembly: Model contracts
    public interface IModelA
    {
        IModelB ModelB { get; }
        ...
    }
    public interface IModelB
    {
        ...
    }
    public interface IModelFactory
    {
        IModelA CreateModelA();
        IModelB CreateModelB();
    }
    // Assembly: DAL contracts, references Model contracts
    public interface IDAL
    {
        IModelA LoadA(int id);
        IModelB LoadB(int id);
    }
    // Assembly: Model implementation, references Model and DAL contracts
    public class ModelA : IModelA
    {
        private IDAL _dal;
        public ModelA (IDAL dal)
        {
            _dal = dal;
        }
        private IModelB _modelB;
        public IModelB ModelB
        {
            get {
                if (_modelB == null) {
                    _modelB = _dal.LoadB(5);
                }
                return _modelB;
            }
        }
    }
    // Assembly: DAL implementation, references Model and DAL contracts
    public class DAL : IDAL
    {
        private IModelFactory _modelFactory;
        
        public DAL(IModelFactory _modelFactory)
        {
            _modelFactory = modelFactory;
        }
        public IModelA LoadA(int id)
        {
            IModelA modelA = _modelFactory.CreateModelA();
            // fill modelA with data from database
            return modelA;
        }
        public IModelB LoadB(int id)
        {
            IModelB modelB = _modelFactory.CreateModelB();
            // fill modelB with data from database
            return modelB;
        }
    }
