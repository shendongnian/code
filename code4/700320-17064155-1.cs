    public Form1()
    {
        InitializeComponent();
        ultraToolbarsManager1.CreationFilter = new HideIcon();
    }
    class HideIcon : IUIElementCreationFilter
    {
        public void AfterCreateChildElements(UIElement parent)
        {
            
        }
        public bool BeforeCreateChildElements(UIElement parent)
        {
            if (parent is PopupToolUIElement)
            {
                parent.Parent.ChildElements.Remove(parent);
            }
            return false;
        }
    }
