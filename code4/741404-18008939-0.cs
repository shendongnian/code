    public static readonly DependencyProperty ChapterProperty = 
        DependencyProperty.Register("Chapter", 
            // property type
            typeof(BibleChapter), 
            // property owner type
            typeof(ChapterBox), 
            null);
    public BibleChapter Chapter
    {
        get { return (BibleChapter)GetValue(ChapterProperty); }
        set { SetValue(ChapterProperty, value); }
    }
