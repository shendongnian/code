    class foo<TParameter, out TReturn> : MulticastDelegate
    {
        public void Invoke(TParameter parameter, IItem item) { ... }
        ....
    }
