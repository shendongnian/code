    interface IGenericDaoBase {
    }
    interface IGenericDao<T> : IGenericDaoBase {
    }
    public class EmpresaDao {
        private IGenericDaoBase parent { get; set; }
        public EmpresaDao(Type type) {
            // same as before
        }
    }
