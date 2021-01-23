    public interface IAggregateRoot { }
    class Test : IAggregateRoot { }
    public interface IRepository<T> where T : IAggregateRoot
    {
        // ...
        IList<T> FindAll();
        void Add(T item);
        // ...
     }
    class Program
    {
        static void Main(string[] args)
        {
            // create Mock
            var m = new Moq.Mock<IRepository<Test>>();
            // some examples
            m.Setup(r => r.Add(Moq.It.IsAny<Test>()));
            m.Setup(r => r.FindAll()).Returns(new List<Test>());
            m.VerifyAll();
        }
    }
