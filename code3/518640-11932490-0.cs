    protected override void SolveInstance(IGH_DataAccess DA)
    {
         if (m_settings == null || m_settings.Length == 0)
         {
             AddRuntimeMessage(
                  GH_RuntimeMessageLevel.Warning,
                  "You must declare some valid settings");
         
             return;
         }
         for (var i = 0; i < m_settings.Length; i ++)
         {
             DA.SetData(i, m_settings[i]);
         }
    }
