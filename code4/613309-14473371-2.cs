    public Random a = new Random(); // replace from new Random(DateTime.Now.Ticks.GetHashCode());
                                    // Since similar code is done in default constructor internally
    public List<int> randomList = new List<int>();
    int MyNumber = 0;
    private void NewNumber()
    {
        MyNumber = a.Next(0, 10);
        if (!randomList.Contains(MyNumber))
            randomList.Add(MyNumber);
    }
