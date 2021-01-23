    void Main()
    {
    	string[,] table = new string[100,2];
    	table[2, 0] = "string1";
    	table[2, 1] = "string2";
    	
    	GetColumn(table, 0).Dump();
    }
    public IEnumerable<T> GetColumn<T>(T[,] array, int columnNum)
    {
    	for (int i = 0; i < array.GetLength(0); i++)
    	{
    		yield return array[i, columnNum];
    	}
    }
    public IEnumerable<T> GetRow<T>(T[,] array, int rowNum)
    {
    	for (int i = 0; i < array.GetLength(1); i++)
    	{
    		yield return array[rowNum, i];
    	}
    }
