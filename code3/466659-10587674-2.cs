     void cbPackage_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var combo = (ComboBox)sender;
            var DataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var DataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)combo.Parent.Parent;
            var source = ((List<ColorData>)DataRepeater.DataSource)[DataRepeaterItem.ItemIndex];
            source.PackageType = (DropData)combo.SelectedValue;        
        }
