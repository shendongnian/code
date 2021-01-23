    class CallAller<T> : HashSet<T>
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
    // Call a simple function
    ca.CallAll(c => c.Start());
    // Call a function taking parameters
    ca.CallAll(c => c.SetRadio(88.1, RadioType.FM));
    // Get return values... if you really need to.
    Dictionary<Car, int> returnValues = new Dictionary<Car, int>();
    ca.CallAll(c => returnValues.Add(c, c.GetNumberOfTyres()));
