    private void Form1_Load(object sender, EventArgs e)
    {
        var test = new Test();
        var panel = new Panel();
        var label = new Label();
        label.Text = "test";
            
        // !!! order is important !!!
        // **************************
        // this works
        test.Controls.Add(panel);
        panel.Controls.Add(label);
        Controls.Add(test);
        // this doesn't work
        //Controls.Add(test);
        //panel.Controls.Add(label);
        //test.Controls.Add(panel);
    }
