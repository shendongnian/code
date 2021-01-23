     int i = 0;
     private void button1_MouseEnter(object sender, EventArgs e)
     {
        button1.FlatStyle = FlatStyle.System;
        i++;
        Console.WriteLine(i.ToString());
     }
    
     private void button1_Down(object sender, EventArgs e)
     {
        button1.FlatStyle = FlatStyle.Standard;
     }
