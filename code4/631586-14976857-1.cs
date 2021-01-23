        if (comboBoxRegion.SelectedValue.ToString() != "0")
        {
            var id = int.Parse(comboBoxRegion.SelectedValue.ToString()
            Widgets = from b in Widgets
                      let currentRegionLog = 
                            b.BatteryRegionLogs
                             .OrderByDescending(item => item.LastModifiedDate)
                             .FirstOrDefault()
                      where currentRegionLog.RegionId == id)
                      select b;
        }
        ... // Same for the other criteria.
        dataGridViewWidget.DataSource = Widgets.ToList();
