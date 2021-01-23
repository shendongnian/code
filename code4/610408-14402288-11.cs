    private void Form1_Load(object sender, EventArgs e)
    {
        var test = new Test();
        var panel1 = new Panel();
        panel1.BackColor = Color.AliceBlue;
        var panel2 = new Panel();
        panel2.BackColor = Color.AntiqueWhite;
        var label1 = new Label();
        label1.Text = "test 1";
        label1.BackColor = Color.Aquamarine;
        var label2 = new Label();
        label2.Text = "test 2";
        label2.BackColor = Color.Azure;
        // !!! order is important !!!
        // first add at least one child control to the test control
        
        // this works as expected
        //Controls.Add(test);
        //test.Controls.Add(panel1);
        //panel1.Controls.Add(panel2);
        //panel2.Left = 50;
        //panel1.Controls.Add(label1);
        //panel2.Controls.Add(label2);
        // this works as expected
        //test.Controls.Add(panel1);
        //Controls.Add(test);
        //panel1.Controls.Add(panel2);
        //panel2.Left = 50;
        //panel1.Controls.Add(label1);
        //panel2.Controls.Add(label2);
        // this doesn't work for panel2 and it's children
        Controls.Add(test);
        panel1.Controls.Add(panel2); // panel2 & children will not trigger the events
        // all controls added to control collections 
        // prior to this line will not trigger the event
        test.Controls.Add(panel1); 
        
        panel2.Left = 50;
        panel1.Controls.Add(label1);
        panel2.Controls.Add(label2); // will not trigger the event
    }
