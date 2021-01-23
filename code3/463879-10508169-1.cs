    // code behind for your xaml
    public partial class MyCodeBehind
    {
      public ObservableCollection<Search> Searches;
      
      public MyCodeBehind()
      {
        InitializeComponent();
      
        Searches = new ObservableCollection<Search>();
        // bind the collection to the ListBox
        this.listSearch.ItemsSource = Searches;
      }
      
      // Deserialize search json data
      public void jsonSearch_GetDataCompleted(object sender, DownloadStringCompletedEventArgs e)
      {
        Search searchData = JsonConvert.DeserializeObject<Search>(e.Result);
      
        if (searchData.results.Count == 0)
        {
          MessageBox.Show("your search didn't return any results");
        }
        else
        {
          // add the results to the existing Searches collection
          foreach (Search search in searchData.results)
          {
            Searches.Add(search);
          }
        }
      }
      
      // Deserialize search next page json data
      public void jsonSearchNextPage_GetDataCompleted(object sender, DownloadStringCompletedEventArgs e)
      {
        Search searchDataPage = JsonConvert.DeserializeObject<Search>(e.Result);
        
        // add the results to the existing Searches collection
        foreach (Search search in searchDataPage)
        {
          Searches.Add(search);
        }
      }
    }
