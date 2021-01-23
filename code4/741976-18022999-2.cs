    for (int i = 0; i < 25; i++){
        Button btn = new Button();
        btn.Text = ...
        btn.Location = new Point(10 + (i%5)*100, (i/5)*30);
        btn.Click += new EventHandler(btn_Click);              // TODO: Implement btn_Click event
        this.Controls.Add(btn);
    }
