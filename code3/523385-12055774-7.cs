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
            this.Invoke((MethodInvoker)delegate
                {             
                    this.NewListEntryEventHandler(sender, e);
                });
            return;
        }
        
        richTextBox1.Text += e.Test;
    }
