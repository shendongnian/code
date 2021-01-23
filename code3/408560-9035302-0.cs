    void LoadSettings()
    {
        if (settings.Contains("DiaryItems"))
        {
            diaryItems = new ObservableCollection<MyDiaryItem>((List<MyDiaryItem>)settings["DiaryItems"]);
        }
    }
    void SaveSettings()
    {
        settings["DiaryItems"] = diaryItems.ToList();
    }
