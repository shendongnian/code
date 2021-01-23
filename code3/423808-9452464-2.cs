    public static void PaperChanged(object sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == 'IsPending') PropertyChanged("IsCheckingPending");
    }
    public static void AddPapers()
    {
        ListPapers = new List<Paper>();
        ListPapers.Add(new Paper() { PaperName = "Paper1", IsPending = false });
        ListPapers.Add(new Paper() { PaperName = "Paper2", IsPending = false });
        ListPapers.Add(new Paper() { PaperName = "Paper3", IsPending = false });
        ListPapers.Add(new Paper() { PaperName = "Paper4", IsPending = false });
        ListPapers.Add(new Paper() { PaperName = "Paper5", IsPending = false });
        foreach(var paper in ListPapers) 
        {
            paper.PropertyChanged += PaperChanged;
        }
    }
