      string m_settings_temp;
                string[] m_settings;
                public void ShowSettingsGui()
                {
                    var dialog = new OpenFileDialog { Filter = "Data Sources (*.ini)|*.ini*|All Files|*.*" };
                    if (dialog.ShowDialog() != DialogResult.OK) return;
    
                    m_settings_temp = File.ReadAllText(dialog.FileName);
                    m_settings = m_settings_temp.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    ExpireSolution(true);
                }
    
    
    
                protected override void SolveInstance(IGH_DataAccess DA)
                {
                    if (m_settings == null)
                    {
                        AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "You must declare some valid settings");
                        return;
                    }
    
                    else
    
                    {  
                            DA.SetDataList(0, m_settings);
                    }  
                   
                }
