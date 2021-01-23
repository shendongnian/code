    public void SetLabel(string message)
    {
        // processing things here
        this.Invoke((MethodInvoker)delegate
        {
            // UI things here
            this.textBox1.Text = message;
        });
        
        MessageBox.Show(message);   
    }    
