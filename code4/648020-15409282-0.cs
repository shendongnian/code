    WindowsUIButton customBackButton;
    public Form1() {
        InitializeComponent();
    
        // add custom button on 'page1' container
        customBackButton = new DevExpress.XtraBars.Docking2010.WindowsUIButton();
        customBackButton.Caption = "Back to Main Tile Container";
        customBackButton.Image = ContentContainerAction.Back.Image;
        page1.Buttons.Add(customBackButton);
        
        page1.ButtonClick += Page_ButtonClick;
        tileContainer1.Click += TileContainer_Click;
    }
    void TileContainer_Click(object sender, TileClickEventArgs e) {
        page1.Document = ((Tile)e.Tile).Document;
        page1.Subtitle = ((Tile)e.Tile).Document.Caption;
        // handle 'tileContainer1' click to activate 'page1' manually
        e.Handled = windowsUIView1.Controller.Activate(page1); 
    }
    const string messageText = "Do you want to navigate back in Main Tile Container?";
    void Page_ButtonClick(object sender, ButtonEventArgs e) {
        if(e.Button == customBackButton) {
            if(MessageBox.Show(messageText, "Back", MessageBoxButtons.YesNo) == DialogResult.Yes)
                windowsUIView1.Controller.Activate(tileContainer1); // activate container
        }
    }
