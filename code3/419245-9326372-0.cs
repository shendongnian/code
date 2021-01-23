    foreach(var pair in SalaryFitmentDictionary)
    {
        if(OHEMDictionary[pair.Key] != pair.Value)
        {
            // This employee's salary has changed
            OHEMDictionary[pair.Key] = pair.Value;
        }
    }
