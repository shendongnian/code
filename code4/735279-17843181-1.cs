    protected void SearchButtonClick(object sender, EventArgs e)
    {
       var text = SearchForm.Text;
       var lockObject = new object();
       Task.Factory.StartNew(() => 
       {
          var resultCount = search.MakeRequests(text );
          lock(lockObject)
          {
              resultsLabel.Text += text + ": " + resultCount + "     occurances";
          }
       });
    }
