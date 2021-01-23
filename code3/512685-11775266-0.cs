    int numberOfColumns = dt.Columns.Count;
    // go through each row
    foreach (DataRow dr in dt.Rows)
    {
        // go through each column in the row
        for (int i = 0; i < numberOfColumns; i++)
        {
            // access cell as set or get
            // dr[i] = "something";
            // string something = Convert.ToString(dr[i]);
        }
    }
