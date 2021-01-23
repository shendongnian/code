    double r = RandomClass.Next (1, 49);
    Num1.Text = r.ToString();
    
    if (r >= 9) 
    {
       this.Num1.BackColor = System.Drawing.Color.DarkBlue;
    }
