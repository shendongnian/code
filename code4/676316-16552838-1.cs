    private ICommand mSortCommand;
    //Implement get and set with NotifyPropertyChanged for mSortableList
    private ICollectionView mSortableList; 
    
    public ICommand SortCommand
    {
      get { return mSortCommand ?? (mSortCommand = new RelayCommand(SortMyList)); } 
    }
    
    public void SortMyList(object sortChosen)
    {
      string chosenSort = sortChosen as string;
      CampaignSortableList.SortDescriptions.Clear();
      Switch(chosenSort){
        "Sort my List"
      }
      CampaignSortableList.Refresh();
    }
