    foreach (var sum in sums)
    {
        test.Add("sum = " + (string)sum.Attribute("sum"));
        //                          ^^^ not subgroup
        test.Add("number = " + (string)sum.Attribute("number"));
        //                             same
    }
