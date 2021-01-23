    for (int i = 0; i < int.Parse(textBox1.Text); i++)
       {
          Button bt = new Button();
          bt.Text = "ok";
          bt.Click += new EventHandler(bt_click);
          bt.Location = new Point(100, i + 200);
          this.Controls.Add(bt);
       }
