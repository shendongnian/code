    private void button2_Click(object sender, EventArgs e)
    {
      tableLayoutPanel1.Padding = new Padding(0, 0, 0, SystemInformation.HorizontalScrollBarHeight);
      for (int i = 0; i < 50; i++)
      {
        Button button = new Button();
        button.Click += new EventHandler(ButtonClick);
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.ColumnCount += 1;
        tableLayoutPanel1.Controls.Add(button);
      }
    }
