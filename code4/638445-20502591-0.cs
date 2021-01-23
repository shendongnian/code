    MenuStrip menu = new MenuStrip() {
      AutoSize = false,
      Dock = DockStyle.Top
    };
    menu.Items.Add("File");
    
    Panel p = new Panel(){
       Dock = DockStyle.Top
    };
    Controls.Add(p);
    Controls.Add(menu);
    MainMenuStrip = menu;
    
    Button b = new Button(){
      Text = "hello world"
    };
    p.Controls.Add(b);
    b.SetBounds(0, 0, 128, 50);
    
