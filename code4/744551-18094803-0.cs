    public class WeaponDatabase : INotifyPropertyChanged
    {
        [XmlArray("Weapons"), XmlArrayItem(typeof(Weapon), ElementName = "Weapon")]
        public ObservableCollection<Weapon> Weapons {get; private set;}
    
        private string path = @"Inventory\WeaponsDB.xml";
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public WeaponDatabase()
        {
            Weapons = new ObservableCollection<Weapon>();
            DeserializeData();
            Weapons.CollectionChanged += Weapons_CollectionChanged;
        }
    
        private void RaiseWeaponsChanged()
        {
            var temp = this.PropertyChanged;
            if(temp != null)
                temp(this, new PropertyChangedEventArgs("Weapons"));
        }
    
        void Weapons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SerializeData();
            DeserializeData();
            RaiseWeaponsChanged()
        }
    
        //Snip
    }
