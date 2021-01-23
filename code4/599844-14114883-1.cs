    public void modStat(string stat, Func<short, short> op)
    {
       switch (stat)
       {
           case "stamina":
               if (staminaCheck.Checked == true)
               { 
                   stamina = op(stamina)
                   staminaText.Text = Convert.ToString(stamina);
               }
               staminaCheck.Checked = false;
               break;
          // more cases
       }
