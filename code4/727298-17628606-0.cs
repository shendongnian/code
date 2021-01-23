    public Form1()
    {
        InitializeComponent();
        Closing += Form1_Closing;
        ApplySavedSplitterData();
    }
    void Form1_Closing(object sender, CancelEventArgs e)
    {
        SaveSplitterData();
    }
    private void SaveSplitterData()
    {
        Settings.Default.SplitterPositions = string.Join(";", 
                         Controls.OfType<SplitContainer>()
                                 .Select(s => s.SplitterDistance));
        Settings.Default.Save();
    }
    private void ApplySavedSplitterData()
    {
        if (string.IsNullOrEmpty(Settings.Default.SplitterPositions))
        {
            return;
        }
        var positions = Settings.Default.SplitterPositions
                                   .Split(';')
                                   .Select(int.Parse).ToList();
        var splitContainers = Controls.OfType<SplitContainer>().ToList();
        for (var x = 0; x < positions.Count && x < splitContainers.Count; x++)
        {
            splitContainers[x].SplitterDistance = positions[x];
        }
    }
