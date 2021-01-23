    public Example2()
    {
        var prop = this.GetType().GetProperty("X");
        Action<int> setter = (Action<int>)Delegate.CreateDelegate(typeof(Action<int>), this, prop.GetSetMethod());
        Func<int> getter = (Func<int>)Delegate.CreateDelegate(typeof(Func<int>), this, prop.GetGetMethod());
    }
