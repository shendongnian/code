    public void ShowSettingsGui()
    {
        var dialog = new OpenFileDialog()
        {
            Multiselect = true,
            Filter = "Data Sources (*.ini)|*.ini*|All Files|*.*"
        };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        var paths = dialog.FileNames;
        var FilePaths = paths.ToDictionary(filePath => filePath, File.ReadAllText);
        // You need to add this
        this.m_settings  = FilePaths;
    }
    
    Dictionary<string, string> m_settings = Filepaths;  
    
    protected override void SolveInstance(IGH_DataAccess DA)
    {
        if (m_settings == null)
        {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "You must declare some valid settings");
            return;
        }
    
        DA.SetData(0, m_settings);
    }
