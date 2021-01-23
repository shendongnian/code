    Dictionary<string, int> lookUpList = new Dictionary<string, int>();
    // Loop through the rows
    for (int i = 0; i < valueArray.GetLength(0); i++)
    {
        // Identify the header rows
        if (valueArray[i, 0].ToString() == "WR")
        {
            // Concatenate the header strings into a single string
            string header = "";
            for (int j = 0; j < valueArray.GetLength(1); j++)
            {
                header += valueArray[i, j].ToString();
            }
            // Store the header location
            lookUpList.Add(header, i + 1);
        }
    }
