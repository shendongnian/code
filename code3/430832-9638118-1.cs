    public class EmpresaDao<T> where T : Empresa {
        private GenericDao<T> parent { get; set; }
        public EmpresaDao() {
            this.parent = new GenericDao<T>();
        }
    }
