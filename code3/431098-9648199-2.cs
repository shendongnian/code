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
    
        fontFamilyList.SelectedItem = fonts.FirstOrDefault(ff => ff.Name == Properties.Settings.Default.FontFamily.Name);
    }
