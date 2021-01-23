    public static unsafe int GetQuotesEx(string ticker, Periodicity periodicity,
                                         int lastValid, int size, Quotation* quotes,
                                         GQEContext* context)
    {
        for (var i = 0; i < 5; i++)
        {
            quotes[i].DateTime = new AmiDate(DateTime.Now.AddDays(i - 5));
            quotes[i].Price = 10;
            quotes[i].Open = 15;
            quotes[i].High = 16;
            quotes[i].Low = 9;
            quotes[i].Volume = 1000;
            quotes[i].OpenInterest = 0;
            quotes[i].AuxData1 = 0;
            quotes[i].AuxData2 = 0;
        }
        return 5;
    }
