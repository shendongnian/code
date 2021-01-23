    public TitleBar titleBar = new TitleBar();
    titleBar.Dock = DockStyle.Top;
    titleBar.MaximizeEnabled = true;
    titleBar.MinimizeEnabled = true;
    titleBar.Size = new System.Drawing.Size(10, 40); // Width doesn't matter - I wanted it 40 pixels tall
    titleBar.Title = "Title Example";
    titleBar.MinButtonClick += titleBar_MinButtonClick;
    titleBar.Max ButtonClick += titleBar_MaxButtonClick;
    this.Controls.Add(this.TitleBar);
