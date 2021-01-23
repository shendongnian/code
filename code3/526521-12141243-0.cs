    void func(int xx, int yy, params object[] arr)
        {
            object value = arr[0];
            Type valueType = value.GetType();
            if (valueType.IsArray)
            {
                Array myArray = (Array)arr[0];
            }
            value = arr[1];
            valueType = value.GetType();
            if (valueType.IsGenericType)
            {
                List<int> myList = (List<int>) arr[1];
            }        
        }
