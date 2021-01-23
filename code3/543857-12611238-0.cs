    private async Task Construct()
    {
      Files = new ObservableCollection<FileViewModel>();
      IsBusy = true;
      IList _files = await _fileRepository.GetFiles();
      IsBusy = false;
      foreach (File file in _files)
      {
        Files.Add(new FileViewModel(file));
      }
    }
