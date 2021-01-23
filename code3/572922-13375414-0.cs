    public void DoSomething (IEnumerable<dynamic> list)
    {
        foreach (dynamic item in list)
        {
            string name = item.Name;
            string lastName = item.LastName;
            int age = item.Age;
        }
    }
