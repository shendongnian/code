    _timers.Add(new Timer(foo.FooMethod, _timers.Count, 10000, Timeout.Infinite));
    
    public class Foo<T>
    {
        public void FooMethod(object stateInfo)
        {
            try
            {
                // Logic here
            }
            finally
            {
                int index = (int)stateInfo;
                _timers[index].Change(10000, Timeout.Infinite);
            }
        }
    }
