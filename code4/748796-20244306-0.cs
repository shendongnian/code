    foreach (DataColumn item in row.Table.Columns)
    {
        switch (item.ColumnName)
        {
    		case "ID":
                {
                    p.ID = Convert.ToInt32(row[item.ColumnName].ToString());
                }
                break;
            case "firstName":
                {
                    p.firstName = row[item.ColumnName].ToString();
                }
                break;
            case "lastName":
                {
                    p.lastName = row[item.ColumnName].ToString();
                }
                break;
                
            default:
                break;
        };
    }
