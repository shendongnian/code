    ...
    System.Windows.Media.Animation.Storyboard storyBoard = (System.Windows.Media.Animation.Storyboard)FindResource("storyboardName");
    storyBoard.Completed += new EventHandler(storyBoard_Completed);
    
    BeginStoryboard(storyBoard);
    ...
    void storyBoard_Completed(object sender, EventArgs e)
    {
        System.Windows.Media.Animation.Storyboard storyBoard = (System.Windows.Media.Animation.Storyboard)FindResource("nextAnim");
        BeginStoryboard(storyBoard);
    }
