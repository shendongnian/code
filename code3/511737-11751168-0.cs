    static void AddNewToClass(object parameter)
    {
        var instance = (TestClass)parameter;
        while (true)
        {
            if (instance.Contains(1))
            {
                continue;
            }    // **thread switch maybe happens here will cause your problem** 
            else
            {
                instance.AddNew(1);
            }
        }
    }
