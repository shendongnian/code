    TextBox tbox8 = new TextBox(); //make it a member variable
    TextBox tbox9 = new TextBox(); //same for this one
    private void button2_Click(object sender, EventArgs e)
    {
        tbox8.Name = "textBox8";
        tbox8.Location = new System.Drawing.Point(54 + (0), 55);
        tbox8.Size = new System.Drawing.Size(53, 20);
        this.Controls.Add(tbox8);
        tbox8.BackColor = System.Drawing.SystemColors.InactiveCaption;
        tbox8.TextChanged += new EventHandler(tbox8_TextChanged);
        tbox9.Name = "textBox9";
        tbox9.Location = new System.Drawing.Point(54 + (60), 55);
        tbox9.Size = new System.Drawing.Size(53, 20);
        this.Controls.Add(tbox9);
        tbox9.BackColor = System.Drawing.SystemColors.InactiveCaption;
        tbox9.TextChanged += new EventHandler(tbox9_TextChanged);
     }//button_click
    //input data into texbox8
    //TextBox tbox;
    double var1;
    private void tbox8_TextChanged(object sender, EventArgs e)
    {
        //tbox = sender as TextBox;
        var1 = Convert.ToDouble(tbox8.Text);//tbox8
    }
    //display the result in textbox9
    //TextBox tbox2;//tbox2 is actually tbox9 anyway
    private void tbox9_TextChanged(object sender, EventArgs e)
    {
    //    tbox2 = sender as TextBox;//so we don't need a tbox2
        //do something with tbox9
    }
    //perform calculation and on button click display data on referenced textbox
    private void button3_Click(object sender, EventArgs e)
    {
        double result2 = var1 * 2;
        //if( null != tbox9 ) 
        //{
            tbox9.Text = result2.ToString(); //changed to tbox9
        //}      
    }
