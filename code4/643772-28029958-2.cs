    private DataTable DictonarysToDataTable(List<Dictionary<string, int>> list) 
        {
            DataTable table = new DataTable();
    
            foreach (Dictionary<string,string> dict in list)        //for every dictonary in the list ..
            {
                foreach (KeyValuePair<string,int> entry in dict) //for every entry in every dict
                {
                    if (!myTable.Columns.Contains(entry.Key.ToString()))//if it doesn't exist yet
                    {
                        myTable.Columns.Add(entry.Key);                 //add all it's keys as columns to the table
                    }
                }
                table.Rows.Add(dict.Values.ToArray());              //add the the Values of every dict in the list as a new row
            }
    
            return table;
        }
