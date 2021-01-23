    public partial class Territory
    {
        public string RegionDescription { get{return Region.Description} set; }
    
        partial void OnRegionIDChanging(int value)
        {
        }
    
        partial void OnRegionIDChanged()
        {
        }
    }
