    var validCombinations = new Dictionary<int, List<int>>();
    validCombinations.Add(Rupee, new List<int> { TaxIndia1, TaxIndia2 });
    validCombinations.Add(Dollar, new List<int> { TaxAmerica1, TaxAmerica2 });
    
    int currencyId = int.Parse(args[0]);
    int taxProfileId = int.Parse(args[1]);
    
    List<int> validTaxes;
    
    if (taxProfileId == 0 ||
        (validCombinations.TryGetValue(currencyId, out validTaxes) &&
         validTaxes.Contains(taxProfileId)))
    {
        Console.WriteLine("All is well!");
    }
    else
    {
        Console.WriteLine("Mismatch Detected!");
    }
