     string[] elems = {"GUID", "CODE", "NAME", "DESCRIPTION"};//Names of the columns 			
        			foreach(string column in elems)
        			{
        				string expression = string.Format("{0} like '%{1}%'",column, txtSearch.Text.Trim());//Search Expression
        				DataRow[] row = data.Select(expression);
        				if(row.Length > 0)
        				{
                       //Some code here
        				} else {
                       //Other code here
        				}
        			}
