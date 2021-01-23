    public static object SafeMethod()
    {
        foreach(var item in list)
        {
            try
            {
                try
                {
                    //Do something that won't transfer control outside.
                }
                catch
                {
                }
            }
            finally
            {
                if (someCondition)
                    return someValue;
                else
                    //No exception will be thrown, so
                    //theoretically this could work.
                    continue;
            }
        }
    }
