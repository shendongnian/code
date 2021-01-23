    public void showAllComments()
        {
            SqlDataReader reader = getCommentsFromDB();
    		List<List<string>> myData; //create list of list
    		int fieldN = reader.FieladCount; //i assume every row in the reader has the same number of field of the first row
    		//Cannot get number of rows in a DataReader so i fill a list
    		while (reader.Read())
    		{
    			//create list for the row
    			List<string> myRow = new List<string>();
    			myData.Add(myRow);//add the row to the list of rows
    			for (int i =0; i < fieldN; i++)
    			{
    				myRow.Add(reader[i].ToString();//fill the row with field data
    			}
    		}
    
            string[,] arrValues = new string[myData.Count, fieldN]; //create the array for the print class
    
    		//go through the list and convert to an array
    		//this could probably be improved 
            for (int i = 0; i < myData.Count; i++)
            {
    			List<string> myRow = myData[i];//get the list for the row
                for (int j = 0; j < nField; j++)
                {
                    arrValues[i, j] = myRow[j]; //read the field
                }
            }
            ArrayPrinter.PrintToConsole(arrValues);
        }
