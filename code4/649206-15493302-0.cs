    public class SampleDataItem : SampleDataCommon
    {
        // add flag as last param
        public SampleDataItem(String uniqueId, String title, String subtitle, 
            String imagePath, String description, String content, SampleDataGroup group, 
            bool isCustomNav = false)
        : base(uniqueId, title, subtitle, imagePath, description)
        {
            this._content = content;
            this._group = group;
            this.IsCustomNav = isCustomNav;
        }
        // to keep it simple this doesn't handle INotifyPropertyChange, 
        // as does the rest of the properties in this class.
        public bool IsCustomNav { get; set; }
        
        ...
    }
