    private Dictionary<string, string> m_settings;  
    
    public void ShowSettingsGui()
    {
        var dialog = new OpenFileDialog()
        {
            Multiselect = true,
            Filter = "Data Sources (*.ini)|*.ini*|All Files|*.*"
        };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        var paths = dialog.FileNames;
        m_settings = paths.ToDictionary(filePath => filePath, File.ReadAllText);
    }
    
    protected override void SolveInstance(IGH_DataAccess DA)
    {
        if (m_settings == null)
        {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "You must declare some valid settings");
            return;
        }
    
        DA.SetData(0, m_settings);
    }
