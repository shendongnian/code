    interface IItem
    {
        //some common properties / methods
    }
    interface IWEapon : IItem
    {
        string Name { get; set; } //maybe this should go to IItem? depends on your actual objects, of course
        //some other wepaon specific properties / methods
    }
    interface IArmor : IItem
    {
        //some properties / methods
    }
    class Inventory
    {
        public Inventory(IWEapon startWeapon, IArmor startArmor)
        {
            CurrentWeapon = startWeapon;
            CurrentArmor = startArmor;
            //optional:
            m_items.Add(startWeapon);
            m_items.Add(startArmor);
        }
        private List<IItem> m_items = new List<IItem>();
        IEnumerable<IItem> InventoryItems
        {
            get { return m_items; }
        }
        void AddItem(IItem item)
        {
            m_items.Add(item);
        }
        IWEapon CurrentWeapon
        {
            get;
            set;
        }
        IArmor CurrentArmor
        {
            get;
            set;
        }
    }
