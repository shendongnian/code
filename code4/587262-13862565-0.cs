    public async Task<bool> GetDefaultData()
    {
        try
        {
            _cancellation = new CancellationTokenSource();
            UpdateProgress(DateTime.Now + ": Download Started.\n");
            List<string> data = await App._apiConnection.DoWorkAsync(_cancellation.Token, ApiInfo.GetBaseDataUriList());
            App._apiConnection.Done(data);
            UpdateProgress(DateTime.Now + ": Countries: " + App._context.Countries.Count() + "\n");
            UpdateProgress(DateTime.Now + ": Regions: " + App._context.Regions.Count() + "\n");
            UpdateProgress(DateTime.Now + ": Income Levels: " + App._context.IncomeLevels.Count() + "\n");
            UpdateProgress(DateTime.Now + ": Indicators: " + App._context.Indicators.Count() + "\n");
            data = await App._apiConnection.DoWorkAsync(_cancellation.Token, ApiInfo.GetCountryUriList("CA"));
            App._apiConnection.Done(data);
            UpdateProgress(DateTime.Now + ": CA Population: " + App._context.PopulationDatas.Count(c => c.Country.Iso2Code == "CA") + "\n");
            data = await App._apiConnection.DoWorkAsync(_cancellation.Token, ApiInfo.GetCountryUriList("US"));
            App._apiConnection.Done(data);
            UpdateProgress(DateTime.Now + ": US Population: " + App._context.PopulationDatas.Count(c => c.Country.Iso2Code == "US") + "\n");
            data = await App._apiConnection.DoWorkAsync(_cancellation.Token, ApiInfo.GetCountryUriList("CN"));
            App._apiConnection.Done(data);
            UpdateProgress(DateTime.Now + ": CN Population: " + App._context.PopulationDatas.Count(c => c.Country.Iso2Code == "CN") + "\n");
            return true;
        }
        catch (OperationCanceledException)
        {
            MessageBox.Show("Operation Cancelled");
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show("getDefaultData Exception: " + ex.Message);
            return false;
        }
    }
