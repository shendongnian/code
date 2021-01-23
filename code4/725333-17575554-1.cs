    private Color offColor = Color.Red;
    private Color onColor = Color.Blue;
    private String btyPrefix = "bty";
    
    private void btyDynamic_click(object sender, EventArgs e)
    {
        Control control = (Control)sender;
        // enumerate this.Controls, but if they go into a different container, enumerate over that
        this.Controls.OfType<Control>()
            .Where(c => ((String)c.Tag).Contains(btyPrefix))
            .ToList<Control>()
            .ForEach(c =>
                {
                    if (control == c)
                        c.BackColor = onColor;
                    else
                        c.BackColor = offColor;
                }
        );
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        Button btyDontChange = new Button();
        btyDontChange.AutoSize = true;
        btyDontChange.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btyDontChange.Text = "x";
        btyDontChange.Tag = "something";
        btyDontChange.Location = new Point(0, 0);
        this.Controls.Add(btyDontChange);
        for (int i = 0; i < 5; i++)
        {
            Button btyDynamic = new Button();
            btyDynamic.Click += new EventHandler(btyDynamic_click);
            btyDynamic.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btyDynamic.AutoSize = true;
            btyDynamic.Text = i.ToString();
            btyDynamic.Tag = btyPrefix + i.ToString();
            btyDynamic.Location = new Point((i+1) * 50, 0);
            btyDynamic.BackColor = offColor;
            this.Controls.Add(btyDynamic);
        }
    }
