    var Qresult =  new List<YourObject>();
    try
    {
        foreach (var r in result)
        {
            if (r.Quantity > 1)
            {
                for (int i = 1; i < r.Quantity; i++)
                {
                    Qresult.Add(r);
                }
            }
        }
    }
