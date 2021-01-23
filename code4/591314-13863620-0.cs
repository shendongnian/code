        void Main()
        {
            var s = (IMyService)new ServiceImpl();
            s.Process(new SomeClass());
        }
    
        public interface IMyService
        {
            void Process(BaseModelType input);
        }
        public interface IMyService<in T> : IMyService
           where T: BaseModelType
        {
            void Process(T input);
        }
        public class BaseModelType{}
        
        public class SomeClass : BaseModelType{}
        public abstract class ServiceBase<T> : IMyService<T>
            where T: BaseModelType
        {
             void IMyService.Process(BaseModelType input)
             {
                 Process((T)input);
             }
        
             public abstract void Process(T input);
        }
        
        public class ServiceImpl : ServiceBase<SomeClass>{
            public override void Process(SomeClass input){}
        }
