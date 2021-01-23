    public interface IMyService
    {
        void Do();
    }
    public class MyService : IMyService
    {
        private readonly Data _data;
        private readonly IDependency _dependency;
        public MyService(Data data, IDependency dependency)
        {
            _data = data;
            _dependency = dependency;
        }
        public void Do()
        {
            throw new System.NotImplementedException();
        }
    }
    public class Data
    {    
    }
    public interface IDependency
    {         
    }
    public class Dependency : IDependency
    {
    }
