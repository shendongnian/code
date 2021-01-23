    public void Change(string stat, bool decrease)
    {
           switch (stat)
           {
               case "stamina":
                   if (staminaCheck.Checked == true)
                   {
                       if(decrease)
                          stamina -= value;
                       else
                          stamina += value;
                       staminaText.Text = Convert.ToString(stamina);
                   }
                   staminaCheck.Checked = false;
                   break;
    
    //There are 5 other similar cases for different stats but to save time I removed them
           }
    }
