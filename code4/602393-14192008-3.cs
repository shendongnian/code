    bool isDirty = false;
    void SomeInitMethod() //ie. Form_Load
    {
        textbox1.TextChanged += new EventHandler(DirtyTextChange);
        textbox2.TextChanged += new EventHandler(DirtyTextChange);
        textbox3.TextChanged += new EventHandler(DirtyTextChange);
        //...etc
    }
    void DirtyTextChange(object sender, EventArgs e)
    {
        isDirty = true;
    }
    void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
