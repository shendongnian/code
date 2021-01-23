    protected void SearchButtonClick(object sender, EventArgs e)
    {
       var lockObject = new object();
       Task.Factory.StartNew(() => 
       {
          var resultCount = search.MakeRequests(SearchForm.Text);
          lock(lockObject)
          {
              resultsLabel.Text += text + ": " + resultCount + "     occurances";
          }
       });
    }
