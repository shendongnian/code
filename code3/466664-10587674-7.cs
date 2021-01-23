        /// <summary>
        /// After Item is cloned, draw item. The index is now available to select the proper data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataForm_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cbPackage", false)[0];
            //Set the selected item based of the list item index
            Combo.SelectedItem = ((List<LineItem>)DataRepeater.DataSource)[e.DataRepeaterItem.ItemIndex].PackageType;  
        }
