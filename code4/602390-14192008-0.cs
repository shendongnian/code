    bool isDirty = false;
    textbox1.TextChanged += new EventHandler(TB_TextChanged);
    textbox2.TextChanged += new EventHandler(TB_TextChanged);
    textbox3.TextChanged += new EventHandler(TB_TextChanged);
    //...etc
    void TB_TextChanged(object sender, EventArgs e)
    {
        isDirty = true;
    }
    void Form1_Closes(object sender, EventArgs e)
    {
        if (isDirty = true) {
            //ask user
        }
    }
