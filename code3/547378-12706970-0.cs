    public object[,] ConvertListToObject<T>(IEnumerable<T> DataSource)
    {
        int rows = DataSource.Count();
        //Get array of properties of the type T
        PropertyInfo[] propertyInfos;
        propertyInfos = typeof(T).GetProperties(BindingFlags.Public);
        int cols = propertyInfos.Length;
        //Create object array with rows/cols
        object[,] excelarray = new object[rows, cols];
        int i = 0;
        foreach (T data in DataSource) //Outer loop
        {
            for (int j = 0; j < cols; j++) //Inner loop
            {
                excelarray[i, j] = propertyInfos[j].GetValue(data, null);
            }
            i++;
        }
        return excelarray;
    }
