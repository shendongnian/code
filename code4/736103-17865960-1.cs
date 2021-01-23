    public class Resources
    {
    	public IList<IResourceItem> ResourceItems {get; set;}
        public double GetTotalMetalStorage(){
            return this.ResourceItems.Sum(x => x.MaxMetalStorage);
        }
    }
