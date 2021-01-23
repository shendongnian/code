    public abstract class BaseClass {
        protected BaseClass(IService service) { }
    }
    public class SubClass : BaseClass {
        public SubClass(IService service) : base(service) { }
    }
