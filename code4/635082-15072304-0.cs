    public class InstrumentDropDownList : DropDownList
    {
       public InstrumentDropDownList()
        {
            PopulateDropDown();
        }
    
        public void PopulateDropDown()
        {
            string unsplitList = Fabric.SettingsProvider.ReadSetting<string>("Setting.Location");
            string[] instrumentList = unsplitList.Split(',');
    
            DropDownList instrumentsDropDown = new DropDownList();
    
            if (instrumentList.Length > 0)
            {
                foreach (string instrument in instrumentList)
                {
                    instrumentsDropDown.Items.Add(instrument);
                }
                instrumentsDropDown.DataBind();
            }
        }
    }   
