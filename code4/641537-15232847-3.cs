    void Main()
    {
    	IObservable<Foo> foos = new [] { new Foo { X = 1 }, new Foo { X = 2 } }.ToObservable();
    	var watcher = new FooWatcher(SynchronizationContext.Current, new Foo { X = 12 });
    	watcher.FooChanged += o => o.X.Dump();	
    	foos.Subscribe(watcher.Subject.OnNext);	
    }
    
    // Define other methods and classes here
    
    //public delegate void FooChangedHandler(Foo foo);
    public interface IFooWatcher
    {
        event Action<Foo> FooChanged;
    }
    
    public class Foo {
    	public int X { get; set; }
    }
    public class FooWatcher
    {
    
        private readonly BehaviorSubject<Foo> m_subject;
    	public BehaviorSubject<Foo> Subject { get { return m_subject; } }
        private readonly IObservable<Foo> m_observable;
    
        public FooWatcher(SynchronizationContext synchronizationContext, Foo initialValue)
        {
            m_subject = new BehaviorSubject<Foo>(initialValue);
    		
            m_observable = m_subject
                .DistinctUntilChanged();
        }
    
        public event Action<Foo> FooChanged
        {
            add { m_observable.ToEvent().OnNext += value; }
            remove { m_observable.ToEvent().OnNext -= value; }
        }
    }
