     public MyHomeworkViewModel()
        {
            allTabs = new ObservableCollection<MyHomeworkModel>();
            selectedTab = new MyHomeworkModel();
            AddCourseCommand = new AddCourseCommand(this);
        }
