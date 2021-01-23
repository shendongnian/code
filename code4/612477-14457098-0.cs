        Panel control1 = new Panel() { Height = 16, Dock = DockStyle.Top, BackColor = Color.Red};
        this.Controls.Add(control1);
        Panel control2 = new Panel() { Height = 16, Dock = DockStyle.Top, BackColor = Color.White };
        this.Controls.Add(control2);
        Panel control3 = new Panel() { Height = 16, Dock = DockStyle.Top, BackColor = Color.Black };
        this.Controls.Add(control3);
        Panel control4 = new Panel() { Height = 16, Dock = DockStyle.Top, BackColor = Color.Yellow };
        this.Controls.Add(control4);
        Panel control5 = new Panel() { Height = 16, Dock = DockStyle.Top, BackColor = Color.Blue };
        this.Controls.Add(control5);
        Panel control6 = new Panel() { Height = 16, Dock = DockStyle.Top, BackColor = Color.Green };
        this.Controls.Add(control6);
        PanelList.Clear();
        PanelList.Add(control1);
        PanelList.Add(control2);
        PanelList.Add(control3);
        PanelList.Add(control4);
        PanelList.Add(control5);
        PanelList.Add(control6);
        Panel control7 = new Panel() { Height = 16, Dock = DockStyle.Top, BackColor = Color.Pink };
        this.Controls.Add(control7);
        PanelList.Insert(3, control7);
        for (int i = 0; i < PanelList.Count; i++)
        {
            PanelList[i].BringToFront();
        }
