     public SelectList VatRatesList
        {
            get
            {
                return new SelectList(
                    new Dictionary<decimal, string>
                    {
                        { 0.0000m, string.Empty },
                        { 1.2000m, "20%"},
                        { 1.0000m, "0%"}
                    }, "Key", "Value");
            }
        }
