    public interface IRepository {
        //Some interfaces
        //This method could only really be implemented if you are using an ORMapper like NHibernate
        public T FindById<T>(Object id) { }
    }
    
    public class BaseRepository : IRepository {
        //Some base crud methods and stuff. You can implement this if you're using an ORMapper
        public T FindById<T>(Object id) 
        { 
            return CurrentSession.FindById<T>(id);
        }
    }
    public class WheelRepository : BaseRepository {
        //Wheel crud
        //If you don't have an ORMapper because you're a masochist you can implement this here
        public Wheel FindById(Object id) { }
    }
    public class CarRepository : BaseRepository {
        //Car crud
        //If you don't have an ORMapper because you're a masochist you can implement this here
        public Car FindById(Object id) { }
    }
    public class BaseService {
        protected BaseRepository _baseRepository;
        //This constructor is automatically called by your IoC container when you want a BaseService
        public BaseService(BaseRepository repository)
        {
            _baseRepository = repository;
        }
        //More methods
    }
    public class WheelService : BaseService
    {
        protected WheelRepository _wheelRepository;
        public WheelService(WheelRepository wheelRepo) : base(wheelRepo)
    }
    public class CarService : BaseService
    {
        protected WheelService _wheelService;
        protected CarRepository _carRepository;
        public CarService(WheelService wheelService, CarRepository carRepository)
        {
            _wheelService = wheelService;
            _carRepository = carRepository;
        }
    }
