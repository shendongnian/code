    public static DataSet MultidimensionalArrayToDataSet(string[,] input)
{
    	var dataSet = new DataSet();
    	var dataTable = dataSet.Tables.Add();
    	var iFila = input.GetLongLength(0);
    	var iCol = input.GetLongLength(1);
 	
    	//Fila
    	for (var f = 1; f < iFila; f++)
    	{
    		var row = dataTable.Rows.Add();
    		//Columna
    		for (var c = 0; c < iCol; c++)
    		{
    			if (f == 1) dataTable.Columns.Add(input[0, c]);
    			row[c] = input[f, c];
    		}
    	}
    	return dataSet;
