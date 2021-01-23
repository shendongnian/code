    private void textBox1_Validating (object Sender, CancelEventArgs e)
    {
        TextBox tx = Sender as TextBox;
        double test;
        if(!Double.TryParse(tx.Text, out test))
        { 
            /* do Failure things */ 
        }
        else //this is the formatting line
            tx.Text = test.ToString("#,##0.00");
    }
