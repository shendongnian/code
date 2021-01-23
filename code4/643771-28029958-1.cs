    private DataTable DictonarysToDataTable(List<Dictionary<string, int>> list) 
        {
            DataTable table = new DataTable();
    
            foreach (Dictionary<string,string> dict in list)        //for every dictonary in the list ..
            {
                foreach (KeyValuePair<string,int> entry in dict) //for every entry in every dict
                {
                    table.Columns.Add(entry.Key);                   //add a column for every Key in every dict in the list
                }
                table.Rows.Add(dict.Values.ToArray());              //add the the Values of every dict in the list as a new row
            }
    
            return table;
        }
