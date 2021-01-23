    DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Check_Constraints, null);
    // Attach delegate Eval() of each Check_Constraints on proper Table/Column
    foreach (DataRow myField in schemaTable.Rows)
    {
        string constraint_name = "";
        string check_clause = "";
        foreach (DataColumn myProperty in schemaTable.Columns)
        {
            if (myProperty.ColumnName == "CONSTRAINT_NAME")
                constraint_name = myField[myProperty.ColumnName].ToString();
            if (myProperty.ColumnName == "CHECK_CLAUSE")
                check_clause = myField[myProperty.ColumnName].ToString();
        }
        var rule = constraint_name.Replace("[", "").Replace("]", "").Split('.');
        if (rule.Length == 3 && dataset.Tables.Contains(rule[0]) && dataset.Tables[rule[0]].Columns.Contains(rule[1]) && String.IsNullOrEmpty(check_clause) == false)
        {
            dataset.Tables[rule[0]].ColumnChanging += delegate (object sender, DataColumnChangeEventArgs e)
            {
                if (e.Column.ColumnName == rule[1] && Convert.ToBoolean(ToolBox.Eval(e.ProposedValue + check_clause)) == false)
                {
                    throw new Exception("Tabela: " + rule[0] + ", coluna: " + rule[0] + ", cheque: " + check_clause);
                }
            };
            Debug.WriteLine(rule[0] + "." + rule[1] + ": " + check_clause);
        }
    }
