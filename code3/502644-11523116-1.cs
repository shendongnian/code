    string title;
    public string Title
    {
       get { return title; }
       set { Set(() => Title, ref title, value); }
    }
