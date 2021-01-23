    public static readonly DependencyProperty ChapterProperty = 
        DependencyProperty.Register("Chapter", 
            // property type
            typeof(BibleChapter), 
            // property owner type
            typeof(ChapterBox), 
            new UIPropertyMetadata(new PropertyChangedCallback(OnChapterChanged)));
    public static void OnChapterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        var chapterBox = (ChapterBox)sender;
        VerseRichTextBuilder builder = new VerseRichTextBuilder();
        var newValue = (Chapter)args.NewValue;
        builder.Build(chapterBox.textBlock, newValue); 
    }
    public BibleChapter Chapter
    {
        get { return (BibleChapter)GetValue(ChapterProperty); }
        set { SetValue(ChapterProperty, value); }
    }
