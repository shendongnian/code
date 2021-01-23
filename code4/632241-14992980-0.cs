    public void SomeMethod()
    {
        foreach (SomeModel x in TheListOfSomeModel)
        {
            var model = x;
            //do some work
            ....
            if (SomeCondition)
            {
                 Task.Factory.StartNew(() => model.ExecuteQuery());
            }
        }
    }
