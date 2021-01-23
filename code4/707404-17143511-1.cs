    Range range = SetRange();//Let's say range is set between A1 to C5
    int rows = 5;
    int columns = 3;
    object[,] data = new object[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; i < columns; j++)
        {
            //Here I build the inside Array[,]
            string uniqueValue = (i + j).ToString();
            data[i, j] = "Insert your value here, e.g: " + uniqueValue;
        }
    }
    object[] args = { data };
    range.GetType().InvokeMember("Value", System.Reflection.BindingFlags.SetProperty, null, range, args);
