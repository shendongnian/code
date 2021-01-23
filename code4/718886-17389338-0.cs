    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < lst.Count; i++) // Loop through List with for
    {
        builder.Append(lst).Append("|"); // Append string to StringBuilder
    }
    string result = builder.ToString(); // Get string from StringBuilder
