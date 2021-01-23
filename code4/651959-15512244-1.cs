    class ItemCollection
    {
        public List<AbstractItem> LibCollection { get; private set; }
        public ItemCollection() {
            this.LibCollection = new List<AbstractItem>();
        }
    }
    class Logic
    {
        ItemCollection ITC;
        public Logic() {
            ITC = new ItemCollection();
        }
        public List<AbstractItem> Search(string TheBookYouLookingFor) {
            foreach (var item in this.ITC.LibCollection) {
                // Do something useful
            }
            return null; // Do something useful
        }
    }
