    private void loadLayout()
    {
        //dockPanelModel.ListUserPanel.Clear();
        //dockPanelModel.ListUserPanelAnchorable.Clear();
        var serializer = new XmlLayoutSerializer(dockManager);
        serializer = new XmlLayoutSerializer(dockManager);
        serializer.LayoutSerializationCallback += (s, args) =>
        {
            args.Content = userPanel;
                    dockPanelModel._ListUserPanelAnchorable.Add(userPanel);
        }
    }
    public AvaladonDockPanel()
    {
        InitializeComponent();
        this.Loaded += AvaladonDockPanel_Loaded;                
    }       
    void AvaladonDockPanel_Loaded(object sender, RoutedEventArgs e)
    {
        loadLayout();          
    }
