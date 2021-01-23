    public class Worker
    {
        private readonly IRepository<One> one;
        private readonly IRepository<Two> two;
        public Worker(IRepository<One> one, IRepository<Two> two)
        {
            this.one = one;
            this.two = two;
        }
        public string DoOne()
        {
            return this.one.Add(new One());
        }
        public string DoTwo()
        {
            return this.two.Add(new Two());
        }
    }
    public interface IRepository<T>
    {
        string Add(T t);
    }
    public class OneRepository : IRepository<One>
    {
        public string Add(One t)
        {
            return "One";
        }
    }
    public class TwoRepository : IRepository<Two>
    {
        public string Add(Two t)
        {
            return "Two";
        }
    }
    public class One { }
    public class Two { }
