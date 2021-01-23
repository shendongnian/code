    partial class NewClass
    {
        public Table<Post> NewProperty
        {
            get
            {
                DoHouseKeeping();
                return this.PropertyFromOtherPartialClass;
            }
        }
    }
