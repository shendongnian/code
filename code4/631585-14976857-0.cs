        if (comboBoxRegion.SelectedValue.ToString() != "0")
        {
            var id = int.Parse(comboBoxRegion.SelectedValue.ToString()
            Widgets = from b in Widgets
                      where b.CurrentRegionLog.RegionId == id)
                      select b;
        }
        ... // Same for the other criteria.
        dataGridViewWidget.DataSource = Widgets.ToList();
