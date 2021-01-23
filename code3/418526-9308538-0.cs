    static IEnumerable<string> GetValuesOfColumn(this Excel.Sheet sheet,int col)
    {
    //returns all the values of the specific column of a sheet
    }
    
    static void WriteValuesToColumn(this Excel.Sheet sheet,IEnumerable<T> values,int col,int row)
    {
    //Writes values to a certain range of a sheet
    }
