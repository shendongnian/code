    public abstract class ClassBase<T, S> : IClass<T>
        where T : MyType
        where S : EntityObject {
    }
    public abstract class ServiceBase<T> where T : MyType {
        protected ServiceBase(IClass<T> classObject) {
            Class = classObject;
        }
        protected IClass<T> Class { get; set; }
    }
    public class ServiceInherited : ServiceBase<MyTypeDerived> {
        public ServiceInherited(IClass<MyTypeDerived> classObject)
            : base(classObject) {
        }
    }
