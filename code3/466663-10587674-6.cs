        void dataForm_ItemCloned(object sender,                Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cbColor", false)[0];
            //Set the data source
            Combo.DataSource = System.Enum.GetValues(typeof(DataRepeater.ColorTypes));
        }
