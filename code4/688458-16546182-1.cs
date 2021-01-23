    // rewrite your trigger constructor like this
    class MyTrigger<TTarget>
    {
        public MyTrigger(TTarget target, Action<TTarget> action);
        public void Activate()
        {
            this._action(this._target);
        }
    }
    
    // now call it with or without parameters
    SomeObject myObj = new SomeObject();
    var trigger = new MyTrigger<SomeObject>(myObj, o => o.Delete(1234));
    trigger.Activate();
