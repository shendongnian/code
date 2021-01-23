    public class BaseDao<T>
    {
        public T Item { get; set; }
    }
    
    public class TestClass
    {
        private BaseDao<object> _dao;
    
        public void RegisterPersistence<T>(BaseDao<T> dao)
        {
            _dao = Activator.CreateInstance<BaseDao<object>>();
            //need to map each member of BaseDao
            _dao.Item = dao.Item;
        }    
    }
