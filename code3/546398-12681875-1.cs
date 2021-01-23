    MainMenu mainMenu = new MainMenu();
    MenuItem menuFile = new CustomMenuItem("File");
    MenuItem menuOpen = new CustomMenuItem("Open");
    MenuItem menuNew = new CustomMenuItem("New");
    public MenuTestForm()
    {
        InitializeComponent();
        this.Menu = mainMenu;
        mainMenu.MenuItems.Add(menuFile);
        menuFile.MenuItems.Add(menuOpen);
        menuOpen.MenuItems.Add(menuNew);
    }
