        public void PopulateDropDown()
        {
            string unsplitList = Fabric.SettingsProvider.ReadSetting<string>("Setting.Location");
            string[] instrumentList = unsplitList.Split(',');
    
            if (instrumentList.Length > 0)
            {
                foreach (string instrument in instrumentList)
                {
                    this.Items.Add(instrument);
                }
            }
        }
