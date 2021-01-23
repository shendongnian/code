    class ItemCollection : IEnumerable<AbstractItem>
    {
        List<AbstractItem> LibCollection;
        public ItemCollection() {
            this.LibCollection = new List<AbstractItem>();
        }
        IEnumerator<AbstractItem> IEnumerable<AbstractItem>.GetEnumerator() {
            return this.LibCollection.GetEnumerator();
        }
        IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return ((IEnumerable)this.LibCollection).GetEnumerator();
        }
    }
    class Logic
    {
        ItemCollection ITC;
        public Logic() {
            ITC = new ItemCollection();
        }
        public List<AbstractItem> Search(string TheBookYouLookingFor) {
            foreach (var item in this.ITC) {
                // Do something useful
            }
            return null; // Do something useful, of course
        }
    }
