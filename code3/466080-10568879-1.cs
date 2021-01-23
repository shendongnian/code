    using MaasOne.Finance.YahooFinance
            
        CompanyStatisticsDownload dl = new CompanyStatisticsDownload();
        dl.Settings.ID = "YHOO";
        Response<CompanyStatisticsResult> resp = dl.Download();
        if (resp.Connection.State == ConnectionState.Success)
        {
            CompanyFinancialHighlights hl = resp.Result.Item.FinancialHighlights;
            double ebitda = hl.EBITDAInMillion * Math.Pow(10, 6);
            //...
        }
