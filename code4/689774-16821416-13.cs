    public class Selector<T> : List<ISelectorNode<T>>
    {
        public static SelectorNode<T, TOut> Get<TOut>(Expression<Func<T, TOut>> selector)
        {
            return new SelectorNode<T, TOut>(selector);
        }
        public void Add<TOut>(Expression<Func<T, TOut>> selector)
        {
            var node = new SelectorNode<T, TOut>(selector);
            Add(node);
        }
    }
    var selector = new Selector<Person>
    {
        Selector<Person>.Get(m => m.Address).Add
        (
            Selector<Address>.Get(x => x.Place),
            Selector<Address>.Get(x => x.ParentName).Add
            (
                Selector<Name>.Get(x => x.Id),
                Selector<Name>.Get(x => x.FirstName),
                Selector<Name>.Get(x => x.Surname)
            )
        ),
        Selector<Person>.Get(m => m.Name).Add
        (
            Selector<Name>.Get(x => x.Id),
            Selector<Name>.Get(x => x.FirstName),
            Selector<Name>.Get(x => x.Surname)
        ),
        
        m => m.Age // <- the change here
    };
