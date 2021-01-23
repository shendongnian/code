        if (ColumnType(DdlColumn1.SelectedValue) == "Date") 
        { 
            sb.AppendFormat("DateTime.Parse({0})", DdlColumn1.SelectedValue); 
            sb.Append(DdlOperator1.SelectedValue); 
            sb.Append(TxtValue1.Text); 
        } 
