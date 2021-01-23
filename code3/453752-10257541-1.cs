    public abstract class BaseClass {
        [ImportingConstructor]
        protected BaseClass(IService service) { }
    }
    [Export]
    public class SubClass : BaseClass {
        public SubClass() { }
    }
