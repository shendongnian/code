        public class WeaponsEditor
        {
            private WeaponsDatabase DB;
            public WeaponsEditor()
            {
                DB = new WeaponsDatabase();
                DB.CollectionChanged += CollectionChanged;
            }
    
            private object CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                // respond to the updated database
            }
        }
