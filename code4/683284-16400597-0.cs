    if (item.IsSet == "J")
    {
      if (MessageBox.Show("Zijn alle bijlagen meegeleverd?", "Bijlagen compleet?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        if (item.DeliveryMethod == "N")
        {
          if (MessageBox.Show("Let op: Dit boek is nieuw geleverd. Accepteer je de kwaliteit van dit boek?", "Kwaliteit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
          {
             // STATUS GEACCEPTEERD
             MessageBox.Show("STATUS GEACCEPTEERD");
          }
          else
          {
             // STATUS NIET GEACCEPTEERD
             MessageBox.Show("STATUS NIET GEACCEPTEERD");
          }
        }    
      }
      else 
      {
        MessageBox.Show("STATUS NIET INGELEVERD"); 
      }
    }
    else
    {
      if (item.DeliveryMethod == "N")
      {
        if (MessageBox.Show("Let op: Dit boek is nieuw geleverd. Accepteer je de kwaliteit van dit boek?", "Kwaliteit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
           // STATUS GEACCEPTEERD
           MessageBox.Show("STATUS GEACCEPTEERD");
        }
       else
        {
           // STATUS NIET GEACCEPTEERD
           MessageBox.Show("STATUS NIET GEACCEPTEERD");
        }
      }
    }
