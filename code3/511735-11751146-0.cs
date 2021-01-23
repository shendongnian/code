    static void AddNewToClass(object parameter)
        {
            var instance = (TestClass)parameter;
            while (true)
            {
                if (instance.Contains(1))
                {
                    continue;
                }  
                else
                {
                    instance.AddNew(1);
                }
            }
        }
