      ManagementClass mc = new ManagementClass("Win32_Service");
      grid.Columns.Add(new DataGridViewTextBoxColumn());
      grid.Columns.Add(new DataGridViewTextBoxColumn());
      grid.Columns.Add(new DataGridViewTextBoxColumn());
      grid.Columns.Add(new DataGridViewTextBoxColumn());
      foreach (ManagementObject mo in mc.GetInstances())
      {
        object col1 = mo["Name"] != null ? mo["Name"].ToString() : null;
        object col2 = mo["Description"] != null ? mo["Description"].ToString() : null;
        object col3 = mo["DisplayName"] != null ? mo["DisplayName"].ToString() : null;
        object col4 = mo["ServiceType"] != null ? mo["ServiceType"].ToString() : null;
        grid.Rows.Add(new object[] { col1, col2, col3, col4 });
      }
