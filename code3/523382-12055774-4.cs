    private void btn_myClass_Click(object sender, EventArgs e)
    {
        MyClass myClass = new MyClass();
        myClass.NewListEntry += NewListEntryEventHandler;
        ...
    }
    
    private void NewListEntryEventHandler(
        object sender,
        NewListEntryEventArgs e)
    {
        if (richTextBox1.InvokeRequired)
        {
            this.BeginInvoke(NewListEntryEventHandler, sender, e);
        }
        else
        {
            richTextBox1.Text += e.Test;
        }
    }
