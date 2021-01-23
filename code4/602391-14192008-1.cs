    bool isDirty = false;
    void SomeInitMethod() //ie. Form_Load
    {
        textbox1.TextChanged += new EventHandler(TB_TextChanged);
        textbox2.TextChanged += new EventHandler(TB_TextChanged);
        textbox3.TextChanged += new EventHandler(TB_TextChanged);
        //...etc
    }
    void TB_TextChanged(object sender, EventArgs e)
    {
        isDirty = true;
    }
    void Form1_Close(object sender, EventArgs e)
    {
        if (isDirty) {
            //ask user
        }
    }
    // to clear
    void Save()
    {
        SaveMyDataMethod();
        isDirty = false;
    }
