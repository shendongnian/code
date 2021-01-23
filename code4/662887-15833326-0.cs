    void OnClick( ... )
    {
      var results = new List<string>();
      var bw = new BackgroundWorker();
	  bw.DoWork += ( s, e ) => CollectData( results );
	  bw.RunWorkerCompleted += ( s, e ) => UpdateUI( results );
	  bw.RunWorkerAsync();
    }
    void CollectData( List<string> results )
    {
      ... build strings and add them to the results list
    }
    void UpdateUI( List<string> results )
    {
      ... update the ComboBox from the results
    }
