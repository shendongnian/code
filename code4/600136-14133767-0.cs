    public DiaryItemDetail DiarySelectedItemId
    {
        get { return _diarySelectedItem.DiarySmileyId; }
    
        set
        {
            if (_diarySelectedItem.DiarySmileyId == value)
            {
                return;
            }
    
            DiarySelectedItem = GetDairyItemDetail(value); // retrieve instance from repository
            RaisePropertyChanged(DiarySelectedItemIdPropertyName);
        }
    }
    public DiaryItemDetail DiarySelectedItem
    {
        get { return _diarySelectedItem; }
    
        set
        {
            if (_diarySelectedItem == value)
            {
                return;
            }
    
            _diarySelectedItem = value;
            RaisePropertyChanged(DiarySelectedItemPropertyName);
            // notification to change the selected item in Coverflow if selected item is changed in code
            RaisePropertyChanged(DiarySelectedItemIdPropertyName);
        }
    }
