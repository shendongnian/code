    Storyboard sb1, sb2;
    public MainWindow()
    {
        InitializeComponent();
        sb1 = (Storyboard)Resources["Storyboard1"];
        sb2 = (Storyboard)Resources["Storyboard2"];
        sb1.Completed += storyboard_Completed;
        sb2.Completed += storyboard_Completed;
    }
    void storyboard_Completed(object sender, EventArgs e)
    {
        string StoryBoardName = ((ClockGroup)sender).Timeline.Name;
        if (StoryBoardName == "Storyboard1_Name") { /* DoSomething(); */ }
        if (StoryBoardName == "Storyboard2_Name") { /* DoSomething(); */ }
    }
