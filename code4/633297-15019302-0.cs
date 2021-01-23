    int intclicks;
    int totalqty;
    
    private void button10_Click(object sender, EventArgs e)
    {
    
        intclicks++;
        if (intclicks > 0)
        {
            totalqty++
            textBox3.Text = totalqty.ToString();
            totalPrice();
            intclicks = 0;
        }
    }
