    public interface IFoo
    {
        bool Foo(Person a, Person b);
    }
    public class KungFoo : FooImpl
    {
        public override bool Foo(Person a, Person b)
        {
            if (this.IsAmateur(a, b))
                return true;
            return false;
        }
    }
    public class KongFoo : FooImpl
    {
        public override bool Foo(Person a, Person b)
        {
            if (this.IsAmateur(a, b))
                return false;
            return true;
        }
    }
    public abstract class FooImpl : IFoo
    {
        public abstract bool Foo(Person a, Person b);
        protected readonly Func<Person, Person, bool> IsAmateur = (a, b) => a.IsAmateur || b.IsAmateur;
    }
    public class Person
    {
        public bool IsAmateur { get; set; }
    }
