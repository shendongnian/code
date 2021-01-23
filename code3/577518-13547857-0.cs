    [Category("Data")]
    [DisplayName("Tabs")]
    [Description("Tabsssssssssssss")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Editor(typeof(ItemsCollectionEditor), typeof(UITypeEditor))]
    public SubItemsCollection Tab {
        get {
            return Items;
        }
    }
