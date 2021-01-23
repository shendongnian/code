    class CallAller<T> : HashSet<T>
    {
        public void CallAll(Expression<Action<T>> expression)
        {
        public void CallAll(Action<T> action)
        {
            foreach (T t in this)
            {
                action(t);
            }
        }
    }
    var ca = new CallAller<Car>();
    ca.Add(myFirstCar);
    ca.Add(mySecondCar);
    ca.CallAll(c => c.Start());
