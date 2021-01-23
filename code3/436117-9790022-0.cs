    DateTime time = DateTime.Parse(txtStartDate.Text); 
        foreach(Button b in this.Controls.OfType<Button>())
        {
            if(b.Name != "button1" || b.Name != "button2")
            {
                 b.Text = time.Date.ToString("dd MMM");
                 time = time.Date.AddDays(1); //setting for next button        
            }
        }
