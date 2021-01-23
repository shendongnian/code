    var taxNumberConverted = new StringBuilder();
    for (int i = 0; i < taxNumber.Length; i++)
    {
        if (i > 0 && taxNumber[i] != taxNumber[i - 1])
        {
            taxNumberConverted.Append(".");
        }
        taxNumberConverted.Append(taxNumber[i]);
    }
    // I have them in groups now ! Yei !
    List<string> groupedNumbers = taxNumberConverted.ToString()
                                                    .Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries)
                                                    .ToList();
