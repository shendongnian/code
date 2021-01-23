    static void buttonCancel_Click(object sender, EventArgs e)
    {
            form.Close();
        buttonOk.Click -= new EventHandler(buttonOk_Click); 
            buttonCancel.Click -= new EventHandler(buttonCancel_Click);
    }
    static void buttonOk_Click(object sender, EventArgs e)
    {
        MessageBox.Show("If u click this, You Will Get many Messages as many as you call the class"); 
        buttonOk.Click -= new EventHandler(buttonOk_Click); 
        buttonCancel.Click -= new EventHandler(buttonCancel_Click);
    }
