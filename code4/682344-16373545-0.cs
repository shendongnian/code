    private void BankAccount()
    {
       if (semafor.WaitOne(0))
       {
           double a = Convert.ToDouble (textBox1.Text) + Convert.ToDouble (textBox2.Text);
           Thread.Sleep(6000);
           semafor.Release(); 
           SetText(a.ToString()); 
       } 
    }
