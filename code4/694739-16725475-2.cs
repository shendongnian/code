    using System;
    
    namespace WpfApplication
    {
        class Item
        {
            public string Name { get; private set; }
            public ItemKind Kind { get; set; }
            public bool IsChecked { get; set; }
            public Uri Link { get; set; }
    
            public Item(string name)
            {
                this.Name = name;
            }
        }
    
        enum ItemKind
        {
            ItemKind1,
            ItemKind2,
            ItemKind3
        }
    }
