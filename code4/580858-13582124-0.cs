    foreach(DataRow tr in transM.Rows)
    {
        foreach(DataRow tb in tableDGV1.Rows)
        {
            if (tr["ID"].ToString() == tb["ID"].ToString())
            {
                string trMitter = tr["Tr"].ToString() + "," + tb["Tr"].ToString();
                string[] trSplit = trMitter.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                IEnumerable<string> noDuplicate = trSplit.Distinct();              
            }
        }
    }
