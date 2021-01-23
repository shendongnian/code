    private async Task<List<string>> ReadAllLinesAsync(string file)
    {
      var ret = new List<string>();
      using (var reader = new StreamReader(file))
      {
        string str = await reader.ReadLineAsync();
        while (str != null)
        {
          ret.Add(str);
          str = await reader.ReadLineAsync();
        }
      }
      return ret;
    }
    private async void button1_Click(object sender, RoutedEventArgs e)
    {
      button1.IsEnabled = false;
      _viewModel.Words = await ReadAllLinesAsync("Words.txt");
      List<string> words;
      switch (_viewModel.RadioButtonWordOrderSelection)
      {
        case MainWindowViewModel.RadioButtonWordOrderSelections.NormalOrder:
          break;
        case MainWindowViewModel.RadioButtonWordOrderSelections.ReverseOrder:
          await Task.Run(() =>
          {
            words = _viewModel.Words.ToList();
            words.Reverse();
          });
          _viewModel.Words = words;
          break;
        case MainWindowViewModel.RadioButtonWordOrderSelections.Shuffle:
          await Task.Run(() =>
          {
            words = _viewModel.Words.Shuffle().ToList();
          });
          _viewModel.Words = words;
          break;
      }
      await DownloadSomething(_viewModel.Words);
      button1.IsEnabled = true;
    }
    private async Task DownloadSomething(IEnumerable<string> words)
    {
      _viewModel.Progress = 0;
      foreach (var word in words)
      {
        _viewModel.Word = word;
        try
        {
          await ...; // async WebClient/HttpClient code here
        }
        catch (Exception e)
        {
          //Trace.WriteLine(e.Message);
        }
        _viewModel.Progress++;
      }
    }
    void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      try
      {
        switch(e.PropertyName)
        {
          case "Progress":
            progress1.Value = _viewModel.Progress;
            break;
          case "Words":
            progress1.Maximum = _viewModel.Words.Count;
            break;
          case "Word":
            labelLastWord.Content = _viewModel.Word;
            break;
          case "RadioButtonWordOrderSelection":
            break;
          default:
            throw new NotImplementedException("[Not implemented for 'Property Name': " + e.PropertyName + "]");
        }
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
      }
    }
