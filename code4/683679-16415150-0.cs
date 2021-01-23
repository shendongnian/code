    public MainForm : Form
    {
        public MainForm()
        {
            ContainerFacade.BuildUp(this);
        }
        [Dependency]
        public ILogger Logger { get; set; }
    }
