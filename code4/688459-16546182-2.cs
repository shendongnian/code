    static class MyTrigger
    {
        public MyTrigger<TTarget> Create<TTarget>(TTarget target, Action<TTarget> action)
        {
            return new MyTrigger<TTarget>(target, action);
        }
    }
    
    // now write the initialization code like this (you don't have to specify the type parameter anymore):
    var trigger = MyTrigger.Create(myObj, o => o.Delete());
