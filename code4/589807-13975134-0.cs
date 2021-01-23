        IDac<T> Build(Action<IModifiableDac<T>> f);
        // other navigation methods
    }
    // modifiable operations, its still an IDac<T>
    public interface IModifiableDac<T> : IDac<T>
    {
        void AddEdge(T item);
        IModifiableDac<T> CreateChildNode();
    }
    // implementation explicitly implements IModifableDac<T> so
    // accidental calling of modification methods won't happen
    // (an explicit cast to IModifiable<T> is required)
    public class Dac<T> : IDac<T>, IModifiableDac<T>
    {
        public IDac<T> Build(Action<IModifiableDac<T>> f)
        {
            f(this);
            return this;
        }
        void IModifiableDac<T>.AddEdge(T item)
        {
            throw new NotImplementedException();
        }
        public IModifiableDac<T> CreateChildNode() {
            // crate, add, child and return it
            throw new NotImplementedException();
        }
        public void DoStuff() { }
    }
    public class DacConsumer
    {
        public void Foo()
        {
            var dac = new Dac<int>();
            // build your graph
            var newDac = dac.Build(m => {
                m.AddEdge(1);
                var node = m.CreateChildNode();
                node.AddEdge(2);
                //etc.
            });
            // now do what ever you want, IDac<T> does not have modification methods
            newDac.DoStuff();
        }
    }
