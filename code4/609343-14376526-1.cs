    foreach (DataRow row in myTopTenData.Rows)
    {
        foreach (DataColumn col in myTopTenData.Columns)
        {
            Console.Write(row[col].ToString() + " ");
        }
        Console.WriteLine();
    }
