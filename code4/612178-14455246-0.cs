    Panel panel;
    Label label;
    Button button1;
    Button button2;
    for(int i = 0; i > count; i++)
    {
        panel = new Panel();
        button1 = new Button();
        button2 = new Button();
        label = new Label();
        panel.Controls.Add(button1);
        panel.Controls.Add(button2);
        panel.Controls.Add(label);
        Controls.Add(panel);
        button1.Click += Event1;
        button2.Click += Event2;
    }
    private void Event1()
    {
        label.Text = "Button 1 Clicked."
    }
    private void Event2()
    {
        label.Text = "Button 2 Clicked."
    }
