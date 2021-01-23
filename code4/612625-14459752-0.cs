    foreach (Control c in this.Controls)
    {
       Button btn = c as Button;
       if (btn != null) // if c is another type, btn will be null
       {
           if (btn.Text.Equals("Button 2"))
           {
               btn.BackColor = Color.GreenYellow;
           }
           else
           { 
               btn.BackColor = Color.PreviousColor;
           }
       }
    }
