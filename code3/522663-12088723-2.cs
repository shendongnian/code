    public void itemSelectionChange(PowerPoint.Selection SelectedItem)
    {
        try
        {
            if (Globals.Ribbons.Ribbon2.itemIDDictionary.ContainsKey(SelectedItem.ShapeRange.Name))
            {
                for (int shapeIDCount = 0; shapeIDCount < Globals.Ribbons.Ribbon2.itemIDDictionary.Count; shapeIDCount++)
                {
                    if (!Globals.Ribbons.Ribbon2.itemIDDictionary.ContainsValue(SelectedItem.ShapeRange[1].Id))
                    {
                        SelectedItem.Delete();
                        MessageBox.Show("You can not copy the browser object.\nAdd a new one using the ribbon bar");
                    }
                }
            }
        }
    catch {}
