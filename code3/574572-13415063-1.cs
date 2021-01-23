    private MySortedList()
    {
    }
    public override void Add(object key, object value)
    {
        if (key == null || value == null)
        {
            //throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
            throw new ArgumentNullException(); // build your own exception, Environment.GetResourceString is not accessible here
        }
        var valuesArray = new object[Values.Count];
        Values.CopyTo(valuesArray , 0);
        int index = Array.BinarySearch(valuesArray, 0, valuesArray.Length, value, _comparer);
        if (index >= 0)
        {
            //throw new ArgumentException(Environment.GetResourceString("Argument_AddingDuplicate__", new object[] { this.GetKey(index), key }));
            throw new ArgumentNullException(); // build your own exception, Environment.GetResourceString is not accessible here
        }
        MethodInfo m = typeof(SortedList).GetMethod("Insert", BindingFlags.NonPublic | BindingFlags.Instance);
        m.Invoke(this, new object[] {~index, key, value});
    }
