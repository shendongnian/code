    public ChooseFontWindow()
    {
        InitializeComponent();
    
        var fonts = 
            from font in Fonts.SystemFontFamilies
            orderby font.Source
            select font;
    
        foreach (FontFamily f in fonts)
        {
            fontFamilyList.Items.Add(f);
        }
    
        fontFamilyList.SelectedIndex = fonts.ToList().IndexOf(Properties.Settings.Default.FontFamily);
    }
