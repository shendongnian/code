    [TestFixture]
    public class ContraVariance
    {
        [Test]
        public void TestNameTest()
        {
            var rules = new List<IRule<object>>(); //object is used just for demo here, probably some interface of yours is better
            rules.Add(new Rule<A>());
            rules.Add(new Rule<B>());
        }
    }
    public class A { }
    public class B { }
    public class Rule<TEntity> : IRule<TEntity>
    {
        
    }
    public interface IRule<out T>
    {
    }
