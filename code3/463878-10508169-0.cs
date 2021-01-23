    // Deserialize search next page json data
    public void jsonSearchNextPage_GetDataCompleted(object sender,  DownloadStringCompletedEventArgs e)
    {
      Search searchDataPage = JsonConvert.DeserializeObject<Search>(e.Result);
      // This adds the results to the actual control which is probably not correct
      // listSearch.Items.Add(searchDataPage.results);
      // This adds the results to the ObservableCollection which is bound the control:
      results.Add(searchDataPage.results);
    }
